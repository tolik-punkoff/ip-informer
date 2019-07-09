<?php
//Только список IP с заголовками HTTP
//Область заголовков
header('Content-type: text/plain; charset=utf8');
//регулярное выражение для IP
$ip_pattern="#(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)#";
// --------- Конец области глобальных переменных ---------

// --------- Область функций ---------

function get_all_info_ip() //получаем информацию о всех IP, из всех переменных HTTP_* сервера
{	
	global $ip_pattern;
	$ret="";
	foreach ($_SERVER as $k => $v) 
	{
		//если нашли в поле HTTP_* (HTTP_VIA, HTTP_X_FORWARDED_FOR и т.д.)
		//что-то похожее на IP
		if ((substr($k,0,5)=="HTTP_") AND (preg_match($ip_pattern,$v)))
		{
			preg_match_all($ip_pattern,$v,$matches); //вытаскиваем из строки все совпадения с шаблоном IP			
			foreach ($matches as $tmp) //preg_match_all выдает многомерный массив
			{
				foreach($tmp as $ip) //вытаскиваем каждый отдельный IP
				{
					$ret.=get_info_ip($k,$ip)."\n"; //получаем информацию для каждого IP
				}								
			}
		}		
	}
	return $ret;
}
	
// ---------Конец области функций ---------

$ip="";

echo "IPINF031\n";
echo "IP|FIELD\n";
echo "---START-DATA---\n";

//данные из REMOTE_ADDR  
$ip = $_SERVER['REMOTE_ADDR'];
echo $ip."|REMOTE_ADDR\n";

//данные заголовков HTTP_
$ip=get_all_info_ip();
echo $ip;
echo "---END-DATA---\n";
?>