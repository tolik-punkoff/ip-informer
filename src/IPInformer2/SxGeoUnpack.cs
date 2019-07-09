using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace SxGeoSharp
{
    public class SxGeoUnpack
    {
        private Dictionary<string, object> RecordData = null;
        private Dictionary<string, Type> RecordTypes = null;
        private Dictionary<string, string> SxTypeCodes = null;

        private Encoding StringsEncoding = null;

        public bool RevBO { get; set; }

        public SxGeoUnpack(string Format, SxGeoEncoding DBEncoding)
        {
            RevBO = !BitConverter.IsLittleEndian;
            
            RecordData = new Dictionary<string,object>();
            RecordTypes = new Dictionary<string,Type>();
            SxTypeCodes = new Dictionary<string,string>();

            //разбираем строку формата
            string[] fields = Format.Split('/');       
            foreach (string field in fields)
            {
                string[] buf = field.Split(':');
                if (buf.Length < 2) break;
                string SxTypeCode = buf[0];
                string FieldName = buf[1];

                //подгатавливаем Dictionary'и
                RecordData.Add(FieldName, null);
                SxTypeCodes.Add(FieldName, SxTypeCode);
                RecordTypes.Add(FieldName,SxTypeToType(SxTypeCode));
            }

            switch (DBEncoding)
            {
                case SxGeoEncoding.CP1251: StringsEncoding = Encoding.GetEncoding(1251); break;
                case SxGeoEncoding.UTF8: StringsEncoding = Encoding.UTF8; break;
                case SxGeoEncoding.Latin1: StringsEncoding = Encoding.GetEncoding(1252); break;
            }
        }
        

        private static Type SxTypeToType(string SxTypeCode)
        {
            if (string.IsNullOrEmpty(SxTypeCode)) return null;
            
            //mediumint - такого типа в C# нет, приведем к int/uint
            switch (SxTypeCode[0])
            {
                case 't': return typeof(sbyte); //tinyint signed - 1 - > sbyte
                case 'T': return typeof(byte); //tinyint unsigned - 1 - > byte
                case 's': return typeof(short); //smallint signed - 2 - > short
                case 'S': return typeof(ushort); //smallint unsigned - 2 - > ushort
                case 'm': return typeof(int); //mediumint signed - 3 - > int
                case 'M': return typeof(uint); //mediumint unsigned - 3 - > uint
                case 'i': return typeof(int); //integer signed - 4 - > int
                case 'I': return typeof(uint); //integer unsigned - 4 - > uint
                case 'f': return typeof(float); //float - 4 - > float
                case 'd': return typeof(double); //double - 8 - > double
                case 'n':                       //number 16bit - 2
                case 'N': return typeof(double); //number 32bit - 4 - > float
                case 'c':                       //char - fixed size string
                case 'b': return typeof(string); //blob - string with \0 end
            }

            return null;
        }
        
        public Dictionary<string, object> Unpack(byte[] Record, out int RealLength)
        {
            int Counter = 0;            
            object buf = null;

            //перебираем сгенерированный ранее словарь с данными
            foreach (string SxRecordName in SxTypeCodes.Keys)
            {
                //вытаскиваем код типа данных
                string SxTypeCode = SxTypeCodes[SxRecordName]; 
                
                //вытаскиваем данные в object buf
                switch (SxTypeCode[0])
                {
                    case 't':
                        {
                            buf = GetTinuintSigned(Record, Counter);
                            Counter++;
                        }; break;
                    case 'T':
                        {
                            buf = GetTinuintUnsigned(Record, Counter);
                            Counter++;
                        }; break;
                    case 's':
                        {
                            buf = GetSmallintSigned(Record, Counter);
                            Counter+=2;
                        }; break;
                    case 'S':
                        {
                            buf = GetSmallintUnsigned(Record, Counter);
                            Counter+=2;
                        }; break;
                    case 'm':
                        {
                            buf = GetMediumintSigned(Record, Counter);
                            Counter += 3;
                        }; break;
                    case 'M':
                        {
                            buf = GetMediumintUnsigned(Record, Counter);
                            Counter += 3;
                        }; break;
                    case 'i':
                        {
                            buf = GetIntSigned(Record, Counter);
                            Counter += 4;
                        }; break;
                    case 'I':
                        {
                            buf = GetIntUnsigned(Record, Counter);
                            Counter += 4;
                        }; break;
                    case 'f':
                        {
                            buf = GetFloat(Record, Counter);
                            Counter += 4;
                        }; break;
                    case 'd':
                        {
                            buf = GetDouble(Record, Counter);
                            Counter += 8;
                        }; break;
                    case 'n':
                        {
                            string signs = SxTypeCode.Substring(1);
                            int isigns = Convert.ToInt32(signs);
                            buf = GetN16(Record, Counter, isigns);
                            Counter += 2;
                        }; break;
                    case 'N':
                        {
                            string signs = SxTypeCode.Substring(1);
                            int isigns = Convert.ToInt32(signs);
                            buf = GetN32(Record, Counter, isigns);
                            Counter += 4;
                        }; break;
                    case 'c':
                        {
                            int length = Convert.ToInt32(SxTypeCode.Substring(1));
                            buf = GetFixedString(Record, Counter, length);
                            Counter += length;
                        }; break;
                    case 'b':
                        {
                            string Result = "";
                            Counter = GetBlob(Record, Counter ,out Result);
                            buf = Result;
                        }; break;
                    default:
                        {
                            buf = null;
                        }; break;
                }

                //записываем полученный объект в соотв. место RecordData
                RecordData[SxRecordName] = buf;
            }

            RealLength = Counter;
            return RecordData;
        }
        
        public Dictionary<string, object> Unpack(byte[] Record)
        {
            int tmp = 0;
            Unpack(Record, out tmp);
            return RecordData;
        }

        private sbyte GetTinuintSigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length)
            {
                return 0;
            }
            else return (sbyte)DataArray[StartPosition];
        }

        private byte GetTinuintUnsigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length)
            {
                return 0;
            }
            else return DataArray[StartPosition];
        }

        private short GetSmallintSigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 1)
            {
                return 0;
            }

            byte[] buf = new byte[2];
            Array.Copy(DataArray, StartPosition, buf, 0, 2);
            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToInt16(buf,0);
        }

        private ushort GetSmallintUnsigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 1)
            {
                return 0;
            }

            byte[] buf = new byte[2];
            Array.Copy(DataArray, StartPosition, buf, 0, 2);
            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToUInt16(buf, 0);
        }

        
        private int GetMediumintSigned (byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 2)
            {
                return 0;
            }

            byte[] buf = new byte[4];

            Array.Copy(DataArray, StartPosition, buf, 0, 3);

            if (RevBO)
            {
                Array.Copy(DataArray, StartPosition, buf, 1, 3);
                Array.Reverse(buf);
            }
            else
            {
                Array.Copy(DataArray, StartPosition, buf, 0, 3);
            }

            return BitConverter.ToInt32(buf, 0);
        }

        private uint GetMediumintUnsigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 2)
            {
                return 0;
            }

            byte[] buf = new byte[4];


            if (RevBO)
            {
                Array.Copy(DataArray, StartPosition, buf, 1, 3);
                Array.Reverse(buf);
            }
            else
            {
                Array.Copy(DataArray, StartPosition, buf, 0, 3);
            }

            return BitConverter.ToUInt32(buf, 0);
        }

        private int GetIntSigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 3)
            {
                return 0;
            }

            byte[] buf = new byte[4];

            Array.Copy(DataArray, StartPosition, buf, 0, 4);

            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToInt32(buf, 0);
        }

        private uint GetIntUnsigned(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 3)
            {
                return 0;
            }

            byte[] buf = new byte[4];

            Array.Copy(DataArray, StartPosition, buf, 0, 4);

            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToUInt32(buf, 0);
        }

        private float GetFloat(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 3)
            {
                return 0;
            }

            byte[] buf = new byte[4];

            Array.Copy(DataArray, StartPosition, buf, 0, 4);

            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToSingle(buf, 0);
        }

        private double GetDouble(byte[] DataArray, int StartPosition)
        {
            if (StartPosition >= DataArray.Length + 7)
            {
                return 0;
            }

            byte[] buf = new byte[8];

            Array.Copy(DataArray, StartPosition, buf, 0, 8);

            if (RevBO)
            {
                Array.Reverse(buf);
            }

            return BitConverter.ToDouble(buf, 0);
        }

        private double GetN16(byte[] DataArray, int StartPosition, int Signs)
        {
            short tmpShort = GetSmallintSigned(DataArray, StartPosition);
            return tmpShort / Math.Pow(10, Signs);            
        }

        private double GetN32(byte[] DataArray, int StartPosition, int Signs)
        {
            int tmpInt = GetIntSigned(DataArray, StartPosition);
            return tmpInt / Math.Pow(10, Signs);         
        }

        private string GetFixedString(byte[] DataArray, int StartPosition, int Count)
        {
            if (StartPosition >= DataArray.Length + Count - 1)
            {
                return null;
            }
            
            //кириллица UTF8 для строк ограниченной длины не поддерживается
            //делаем буфер
            byte[] buf = new byte[Count];

            //копируем нужное количество байт в буфер
            Array.Copy(DataArray, StartPosition, buf, 0, Count);

            return StringsEncoding.GetString(buf);            
        }

        private int GetBlob(byte[] DataArray, int StartPosition, out string Result)
        {            
            int i = StartPosition;            
            List<byte> tmpl = new List<byte>();
            while (DataArray[i] != '\0')
            {                
                tmpl.Add(DataArray[i]);
                i++;                
            }
            i++;
            byte[] buf = tmpl.ToArray();
            Result = StringsEncoding.GetString(buf);
            return i;
        }

        /*public static float ConvertToFloat(string Value, string DecimalSeparator)
        {
            NumberFormatInfo format = new NumberFormatInfo();
            format.NumberDecimalSeparator = DecimalSeparator;
            return Convert.ToSingle(Value, format);
        }*/

        //--------------------------------
        public Dictionary<string, Type> GetRecordTypes()
        {
            return RecordTypes;
        }
        public Dictionary<string, string> GetSxTypeCodes()
        {
            return SxTypeCodes;
        }
        public static Dictionary<string, Type> GetRecordTypes(string Format)
        {
            Dictionary<string, Type> tmpTypes = new Dictionary<string, Type>();
            string[] fields = Format.Split('/');
            foreach (string field in fields)
            {
                string[] buf = field.Split(':');
                if (buf.Length < 2) break;
                string SxTypeCode = buf[0];
                string FieldName = buf[1];

                //формируем Dictionary
                tmpTypes.Add(FieldName, SxTypeToType(SxTypeCode));
            }
            return tmpTypes;
        }

    }
}