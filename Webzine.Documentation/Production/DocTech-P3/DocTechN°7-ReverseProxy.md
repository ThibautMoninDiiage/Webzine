## Configuration reverse proxy :

Tout d'abord, on installe nginx sur notre serveur Debian 11 :

    apt install nginx

Nous créons tout "nos sites" dans (/etc/nginx/sites-available/) 

Nous avons l'arborescence : 

    enter

Par exemple pour elk nous avons le fichier "elk.conf" :

    upstream elk {
	    server 192.168.30.253;
	}
	server {
		listen 5601;
	server_name elk-g2.g1;
	location / {
		proxy_pass http://elk-g2.g1:5601;
		proxy_set_header  Host $host;
		proxy_connect_timeout 30;
		proxy_send_timeout 30;
		}
	}

Pour serveur zabbix : 

    upstream zabbix-g2.g1 {
	    server 192.168.40.253;
	    }
	server {
		server_name zabbix-g2.g1;
		location / {
			proxy_pass http://zabbix-g2.g1;
			proxy_set_header  Host $host;
			proxy_connect_timeout 30;
			proxy_send_timeout 30;
		}
	}
  
  Pour serveur Webzine :

    upstream webzine-g2.g1 {
	    server 192.168.40.253;
	    }
	server {
		server_name webzine-g2.g1;
		location / {
			proxy_pass http://webzine-g2.g1;
			proxy_set_header  Host $host;
			proxy_connect_timeout 30;
			proxy_send_timeout 30;
		}
	}

Désormais grace à cette configuration nous pouvons aller sur notre navigateur :

    http://zabbix-g2.g1/zabbix.php?action=dashboard.view
    http://elk-g2.g1:5601/login?next=%2F
    http://webzine-g2.g1

 
