## Fail2ban pour Nginx :

Nous commençons par faire une Maj de notre machine :

    apt update && apt upgrade

Nous commençons par installer le paquet fail2ban :

    apt install fail2ban

Ensuite nous allons dans /etc/fail2ban/filter.d/nginx-4xx.conf :

    [Definition]
    failregex = ^<HOST>.*"(GET|POST).*" (404|444|403|400) .*$
    ignoreregex = .*(robots.txt|favicon.ico|jpg|png)

Nous enregistrons. 

Validations des règles :

	   fail2ban-regex /var/log/nginx/access.log /etc/fail2ban/filter.d/nginx-4xx.conf

Ensuite dans jail.d/nginx.conf :

    [nginx-4xx]
    enabled  = true
    port     = http,https
    filter   = nginx-4xx
    logpath  = /var/log/nginx/*.log
    maxretry = 7
    findtime = 300
    bantime = 600
    
Nous enregistrons et redémarrons fail2ban :

    systemctl restart fail2ban

Pour tester :

    fail2ban-client status nginx-4xx    

Installation terminée. 

