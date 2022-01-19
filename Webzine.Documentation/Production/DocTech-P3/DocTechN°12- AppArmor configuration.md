## AppArmor configuration :

*Pour la machine SRVNGINXPROX :* 

Nous installons les paquets suivants : 

    apt update && apt install apparmor-profiles apparmor-profiles-extra
    apt install apparmor-utils

Nous éditons le fichier : 

    nano /etc/apparmor.d/abstractions/ssl_certs

On n'ajoute les fichiers suivants :

    /etc/letsencrypt/*-certs/*/cert.pem r, 
    /etc/letsencrypt/*-certs/*/chain.pem r, 
    /etc/letsencrypt/*-certs/*/fullchain.pem r,

On créer le fichier ci-dessous : 

    nano /etc/apparmor.d/usr.sbin.nginx
   
  Nous remplissons le fichier :

    #include <tunables/global> 
    
    /usr/sbin/nginx flags=(complain) { 
	    #include <abstractions/apache2-common> 
	    #include <abstractions/base> 
	    #include <abstractions/nameservice> 
	    #include <abstractions/openssl> 
	    #include <abstractions/ssl_keys> 
	    
	    capability dac_override, 
	    capability dac_read_search, 
	    capability setgid, 
	    capability setuid, 
	    
	    deny / rw, 
	    deny /bin/bash r, 
	    
	    /usr/local/modsecurity/lib/lib*so* mr, 
	    /usr/sbin/nginx mr, 
	    /var/log/modsec_audit.log wk, 
	    /var/log/nginx/*.log w, 
	    owner /etc/nginx/bots.d/*.conf r, 
	    owner /etc/nginx/conf.d/ r, 
	    owner /etc/nginx/conf.d/*.conf r, 
	    owner /etc/nginx/custom-config/*.conf r, 
	    owner /etc/nginx/mime.types r, 
	    owner /etc/nginx/modsec/*.conf r, 
	    owner /etc/nginx/modsec/owasp-modsecurity-crs/ r, 
	    owner /etc/nginx/modsec/owasp-modsecurity-crs/**.conf r,
	    owner /etc/nginx/modsec/owasp-modsecurity-crs/**.data r, 
	    owner /etc/nginx/modsec/owasp-modsecurity-crs/rules/ r,
	    owner /etc/nginx/modsec/unicode.mapping r, 
	    owner /etc/nginx/nginx.conf r, 
	    owner /etc/nginx/sites-available/* r, 
	    owner /etc/nginx/sites-enabled/ r, 
	    owner /etc/nginx/uwsgi_params r, 
	    owner /run/nginx.pid rw, 
	    owner /usr/share/GeoIP/*.mmdb r, owner /var/cache/nginx/** rw, }

Nous redémarrons le service :

    systemctl restart apparmor

Recherche d'autres régles

    aa-logprof

Répétez ce processus jusqu'à ce qu'aa-logprof ne trouve plus de règles.

Une fois que vous êtes satisfait du profil, vous pouvez l'appliquer avec :

    aa-enforce usr.sbin.nginx

Nous pouvons faire un : 

    aa-status


*Pour la machine SRVDEBELK :* 

Nous installons les paquets suivants : 

    apt install apparmor-utils

Nous faisons : 

    aa-enabled

Puis nano /etc/apparmor.d/usr.bin.test :

    #include <tunables/global>  
    profile test /usr/lib/test/test_binary 
    {
	#include <abstractions/base>      
    # Main libraries and plugins     
    /usr/share/TEST/** r,
    /usr/lib/TEST/** rm,
    # Configuration files and logs     
    @{HOME}/.config/ r,     
    @{HOME}/.config/TEST/** rw, 
    }

Nous redémarrons le service :

    systemctl restart apparmor

Recherche d'autres régles

    aa-logprof


