# **Dossier de déploiement on premise**


## Installation de Docker sur Debian 11 :

Nous devons faire une mise à jour de notre Debian 11 (Obligatoire) :

    apt update && apt full-upgrade -y
Ensuite nous pouvons installer les dépendances suivantes : 

    apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg \
    lsb-release

Ajout de la clé GPG officielle de Docker : 

    curl -fsSL https://download.docker.com/linux/debian/gpg | gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

Ajout du repository Docker dans les sources :

    echo \"deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/debian \ $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

Mise à jour des sources :

    apt update

Téléchargement de docker depuis les sources :

    apt install docker-ce docker-ce-cli containerd.io
    
L'installation de Docker est finit. 


## Installation de portainer pour docker :

Création du volume : 

    docker volume create portainer_data

Téléchargement de Portainer : 

    docker run -d -p 8000:8000 -p 9443:9443 --name portainer \ --restart=always \ -v /var/run/docker.sock:/var/run/docker.sock \ -v portainer_data:/data \ cr.portainer.io/portainer/portainer-ce:2.9.3

Une fois portainer installé nous pouvons tester en tapant l'URL dans notre navigateur : 

    https://localhost:9443


## Installation de Zabbix sur trois serveur :

Sur les trois serveurs nous exécutons les commandes suivantes : 

    wget https://repo.zabbix.com/zabbix/5.0/debian/pool/main/z/zabbix-release/zabbix-release_5.0-2+debian11_all.deb

    dpkg -i zabbix-release_5.0-2+debian11_all.deb
    
    apt update

Sur la VM de la BDD : 

    apt install postgresql postgresql-contrib

Création de la BDD de Zabbix et Ajout de l'utilisateur ZAbbix dans PostGreSQL : 

    sudo -u postgres createuser --pwprompt zabbix

*Nous saisissons zabbix comme mot de passe.*

Nous exécutons la commande suivante : 

    sudo -u postgres createdb -O zabbix zabbix

Nous téléchargeons le fichier suivant (Squellette de la BDD) : 

    https://groupesbtest-my.sharepoint.com/:u:/g/personal/hugo_zahn_diiage_org/ERr_RjfmRpFOrAyweUZZdvIBk2XpLmTnMQgzPXf47U5Lcw?e=1aqpbT](https://groupesbtest-my.sharepoint.com/:u:/g/personal/hugo_zahn_diiage_org/ERr_RjfmRpFOrAyweUZZdvIBk2XpLmTnMQgzPXf47U5Lcw?e=1aqpbT "https://groupesbtest-my.sharepoint.com/:u:/g/personal/hugo_zahn_diiage_org/ERr_RjfmRpFOrAyweUZZdvIBk2XpLmTnMQgzPXf47U5Lcw?e=1aqpbT"

On télécharge le fichier et on l'envoie sur la machine de BDD dans le répertoire /tmp. 
Puis nous tapons la commande suivante : 

    zcat create.sql.gz | sudo -u zabbix psql zabbix

Autorisation des connexions à distance pour PostGreSQL : 

    nano /etc/postgresql/13/main/postgresql.conf 
    listen_addresses ='*' 
    
    nano /etc/postgresql/13/main/pg_hba.conf 
    host all all @IP[front] md5 
    
    systemctl restart postgresql 
    systemctl enable postgresql

Sur la VM FRONT (Apache2) :

Nous installons les paquets suivants : 

    apt install zabbix-frontend-php zabbix-apache-conf php7.4-pgsql

Copier le fichier de configuration de Zabbix et nous le mettons dans le répertoire de configuration d'Apache : 

    cp /etc/zabbix/apache.conf /etc/apache2/sites-available/ 
    mv /etc/apache2/sites-available/000-default.conf /tmp 
    mv /etc/apache2/sites-available/default_ssl.conf /tmp

Nous éditons le fichier suivant :

    nano /etc/php/7.4/apache2/php.ini 
    [Date] 
    ;Defines the default timezone used by the date functions
    ;http://php.net/date.timezone 
    date.timezone = Europe/Paris

Nous modifions les deux valeurs suivantes :

    nano /etc/zabbix/apache.conf 
    php_value date.timezone Europe/Paris 

Nous redémarrons le service apache 2 :

    systemctl restart apache2 
    systemctl enable apache2

Sur la VM Back :

installation des paquets suivants sur le serveur Zabbix : 

    apt install zabbix-server-pgsql

Nous éditons le fichier suivant : 

    nano /etc/zabbix/zabbix_server.conf 
    DBPassword=zabbix 
    DBHost=@IP[BDD] 
    systemctl restart zabbix-server

L'installation est terminée. 

    Accès: @IP[front]/zabbix
    Vérification que tout est en vert
    Configuration de la BDD: Database host: @IP[BDD] Password: zabbix
    Configuration server: Host: @IP[ZABBIXSERVER] Name: Nom du zabbix ( like you want)
    Suivant
    ID de co: Admin/zabbix


## Sauvegarde des fichiers de configuration :

Sur la machine de Sauvegarde nous installons "rsync" :

    apt-get install rsync

Nous éditons le fichier /etc/rsyncd.conf :

    max connections = 7
    log file = /var/log/rsync.log
    timeout = 300
    
    auth users = sauvegarde
    secrets file = /etc/rsyncd.secrets
    
    uid = sauvegarde
    gid = sauvegarde
    
    [sauvegarde]
    path = /sauvegarde
    hosts allow=*
    hosts deny = *
    comment = svg
    read only = false
    
    [zabbix]
    path = /zabbix
    hosts allow=*
    hosts deny = *
    comment = svg
    read only = false
    
    [frontzabbix]
    path = /frontzabbix
    hosts allow=*
    hosts deny = *
    comment = svg
    read only = false
    
    [portainer]
    path = /portainer
    hosts allow=*
    hosts deny = *
    comment = svg
    read only = false
    
    [reversenginx]
    path = /reversenginx
    hosts allow=*
    hosts deny = *
    comment = svg
    read only = false

Nous rajoutons tout les partages que nous avons besoin. 

Nous ajoutons l'utilisateur suivant : 

    adduser sauvegarde --shell /bin/false --disabled-password

Puis nous créons l'arborescence :

    mkdir /sauvegarde 
    mkdir /frontzabbix 
    mkdir /zabbix
    mkdir /reversenginx
    mkdir /portainer
    chown -R sauvegarde.sauvegarde /sauvegarde
    chown -R sauvegarde.sauvegarde /frontzabbix 
    chown -R sauvegarde.sauvegarde /zabbix 
    chown -R sauvegarde.sauvegarde /reversenginx
    chown -R sauvegarde.sauvegarde /portainer
    chmod 770 -R /sauvegarde
    chmod 770 -R /frontzabbix
    chmod 770 -R /zabbix
    chmod 770 -R /reversenginx    
    chmod 770 -R /portainer

Sur la vm BDD nous créons l'arborescence : 

    mkdir /DB/backup 

Puis on créer un script suivant : 

    #Sauvegarde en .sql de la BDD ZABBIX
    pg_dump -h localhost -U zabbix -W zabbix zabbix > /DB/backup/dump_file_SV.sql
    
    #Sauvegarde envoyer sur le serveur
    #!/bin/bash
    hostrsync="192.168.30.252"
    utilisateurrsync=sauvegarde
    export RSYNC_PASSWORD=root
    
    rsync -rlptD --stats /DB/backup/dump_file_SV.sql $utilisateurrsync@$hostrsync::sauvegarde

Pour toutes les autres machines on créer le script suivant que nous mofions pour chaque machine : 

    #Sauvegarde envoyer sur le serveur
    #!/bin/bash
    hostrsync="192.168.30.252"
    utilisateurrsync=sauvegarde
    export RSYNC_PASSWORD=root
    
    rsync -rlptD --stats /etc/zabbix/apache.conf $utilisateurrsync@$hostrsync::frontzabbix

Puis dans chaque machine nous éditons le crontab : 

    crontab -e

Nous ajoutons la ligne suivante : 

    00 01 * * * /script/scriptbackup.sh

La sauvegarde s'effectue chaque jour à 01:00h du matin. 

Les sauvegardes sont terminées et mis en place. 


# Chapitre 1   
#### Table des matières
1. [Téléchargement et installation d'ELK](#Telechargement-et-instalation-d'ELK)
2. [Installation de l'agent filebeat](#Installation-de-l'agent-filebeat)
3. [Manipulations sur la GUI de Kibana](#Manipulations-sur-la-GUI-de-Kibana)

## Téléchargement et installation d'ELK   
Téléchargez le repository suivant :  
```http
https://github.com/deviantony/docker-elk  
```
Une fois téléchargé, ouvrez un terminal (ou celui intégré avec VSCode) et déplacez-vous dans le dossier racine du repository.
Lancez :
```
docker-compose up -d
```
Une fois installé, connectez-vous sur l'interface de gestion : 
```http
http://localhost:5601  
```
Pour accéder à l'interface :
```yml
user: elastic
password: changeme
```

## Installation de l'agent filebeat
Sur votre serveur Zabbix ayant un Apache2 installé, téléchargez et installez l'agent `filebeat` :
```bash
curl -L -O https://artifacts.elastic.co/downloads/beats/filebeat/filebeat-7.16.2-amd64.deb
dpkg -i filebeat-7.16.2-amd64.deb
```
Activez l'agent au démarrage de la machine :
```bash
systemctl enable filebeat.service
```
Editez le fichier de configuration de l'agent :
```bash
nano /etc/filebeat/filebeat.yml
```
<b><span style="color:Red">ATTENTION : Les fichiers de configuration sont au format YAML, les espaces dans les fichiers sont importants.</span></b>  

A la section : `setup.kibana:`, décommentez et ajoutez l'IP de votre serveur hôte (hébergeant ELK) :    
```yml
#host: "localhost:5601"  (Ancienne valeur)
host: "192.168.1.33:5601"
```
A la section : `output.elasticsearch:` :  
```yml 
#hosts: ["localhost:9200"] (Ancienne valeur)
hosts: ["192.168.1.33:9200"]
username: "elastic"
password: "changeme"
```
Une fois modifié et enregistré, listez tous les modules proposés par cet agent :  
```bash
filebeat modules list
```  
Activez le module dédié à Apache :
```bash
filebeat modules enable apache
```
Editez le fichier du module :
```bash
nano /etc/filebeat/modules.d/apache.yml
```
Décommenter pour la partie `access` et `error` et ajoutez :
```yml
# Access logs
#var.paths:(Ancienne valeur)
var.paths: ["/var/log/apache2/access*.log*"]
# Error logs
#var.paths: (Ancienne valeur)
var.paths: ["/var/log/apache2/error*.log*"]
```
Testez votre configuration :
```bash
filebeat test config
```
Appliquez la configuration de l'agent :
```bash
systemctl restart filebeat.service
```
Pour créer une structure de filtres, d'indexation et de dashboard automatiquement par l'agent lui-même :
```bash
filebeat setup -e
```
_Note : Attention à la disponibilité des ports `9200` (TCP) et `5601` (TCP) dans le firewall de votre machine hôte._

## Manipulations sur la GUI de Kibana
Sur l'interface Kibana, accédez au dashboard précédemment créé par l'agent 
`Filebeat` :  
`Analytics` &#10132; `Dashboard` &#10132; `[Filebeat Apache] Access and error logs ECS`  
Pour voir toutes les requêtes en live :  
`Observability` &#10132; `Logs` &#10132; `Stream`  
Cliquez sur `Stream Live` et rafraichissez votre interface web Zabbix pour voir des accès en direct.  

### Journaux syslog
Faites de même avec les journaux `syslog` et `auth` de votre serveur Zabbix en ajoutant le module `system` :  
Activez le module `system` de `Filebeat` :
```bash
filebeat modules enable system
```
Editez le fichier de module dédié :
```bash
nano /etc/filebeat/modules.d/system.yml
``` 
```yml
# Syslog
#var.paths: (Ancienne valeur)
var.paths: ["/var/log/syslog*"]

# Authorization logs
#var.paths: (Ancienne valeur)
var.paths: ["/var/log/auth*"]
```
Redémarrez l'agent pour appliquer la nouvelle configuration :
```bash
systemctl restart filebeat.service
```
Vous pouvez aller observer le résultat sur le dashboard dédié Kibana :
`Analytics` &#10132; `Dashboard` &#10132; `[Filebeat System] Syslog dashboard ECS`  

### Bonus 
Créez-vous même vos propres `Dashboard` en allant sur :
`Analystics` &#10132; `Dashboard` &#10132; `Create dashboard`   

**Fin du TD pour le chapitre 1.**  

## Renforcement de Zabbix Server
Pour commencer, installez les composants nécessaires à votre serveur pour configurer des règles AppArmor :  
```bash
apt install apparmor-utils
```
Listez l'ensemble des règles déjà actives sur votre machine :
```bash
aa-status
```
Listez l'ensemble des processus qui pourraient recevoir un renforcement sur votre machine (qui ont un port d'écoute ouvert) :
```bash
aa-unconfined
```
Pour renforcer le service `zabbix_server` avec les outils dédiés, il faut commencer par créer la structure du fichier de profil avec :
```bash
aa-autodep zabbix_server
```
Vous pouvez aller lire le contenu de ce nouveau fichier généré avec :
```bash
more /etc/apparmor.d/usr.sbin.zabbix_server
```
_Note : Si vous faites de nouveau un `aa-status` vous pouvez constater que `Zabbix Server` est en état `unconfined`. Un profil existe, mais il n'est pas chargé._  

Positionnez vous dans le répertoire `/etc/apparmor.d` puis passez l'état de du service `zabbix-server` du mode `unconfined` à `complain` avec :
```bash
aa-complain usr.sbin.zabbix_server
```
Cette commande aura pour effet de journaliser tous les éléments exécutés par le binaire `zabbix_server` dans le fichier syslog.
```bash
tail -f /var/log/syslog
```
Vous allez observer de nombreuses lignes comme celui-ci :  
```log
Dec 26 10:45:58 ubuntuarm kernel: [  369.440619] audit: type=1400 audit(1640515558.211:177): apparmor="ALLOWED" operation="mknod" profile="/usr/sbin/zabbix_server" name="/run/zabbix/zabbix_server_alerter.sock" pid=2651 comm="zabbix_server" requested_mask="c" denied_mask="c" fsuid=112 ouid=112
...
```
_Note : Si vous faites de nouveau un `aa-status` vous pouvez constater que `Zabbix Server` est en état `complain`._  

Maintenant, il faut manipuler un maximum le service pour logger l'ensemble de ses accès. Au plus basique :
```bash
service zabbix-server stop
service zabbix-server start
```
Une fois effectué, vous pouvez commencer à enregistrer les autorisations dans le fichiers de règle dédié avec :
```bash
aa-logprof
```
Exemple de ce que l'interface peut vous demander :
```log
Reading log entries from /var/log/syslog.
Updating AppArmor profiles in /etc/apparmor.d.
Complain-mode changes:

Profile:    /usr/sbin/zabbix_server
Capability: setgid
Severity:   9

 [1 - #include <abstractions/dovecot-common>]
  2 - #include <abstractions/postfix-common> 
  3 - capability setgid, 
(A)llow / [(D)eny] / (I)gnore / Audi(t) / Abo(r)t / (F)inish
```
_Note : Vous pouvez avoir dans un premier temps, cette demande :_
```bash
(I)nherit / (C)hild / (N)amed / (U)nconfined / (X) ix On / (D)eny / Abo(r)t / (F)inish
```
_En ce cas, tapez `I` pour demander un listing des demandes d'accès._

Etant en phase de création, nous allons autoriser toutes les demandes. Pour cela, tapez `A` sur chaque demandes jusqu'à avoir :
```log
The following local profiles were changed. Would you like to save them?

 [1 - /usr/sbin/zabbix_server]
(S)ave Changes / Save Selec(t)ed Profile / [(V)iew Changes] / View Changes b/w (C)lean profiles / Abo(r)t
```
Faites `S` pour sauvegarder les nouvelles entrées.  
Vous pouvez lire l'ensemble de ces nouvelles entrées :
```bash
more /etc/apparmor.d/usr.sbin.zabbix_server
```
Passez ensuite votre service `zabbix server` du mode `complain` à `enforce` pour bloquer et journaliser tous les accès non désirés avec :
```bash
aa-enforce usr.sbin.zabbix_server
```
Redémarrez votre service Zabbix Server pour voir si tout fonctionne toujours :
```bash
service zabbix-server stop
service zabbix-server start
```
Vous pouvez constater que le service est bien en état `renforcé` avec :
```bash
aa-status
```
Dans le cas ou les choses ne se passent pas bien, il faut aller lire le fichier syslog `/var/log/syslog` et `/var/log/zabbix/zabbix_server.log` pour constater un problème d'accès (lié au blocage par AppArmor).  
Si le service ne démarre pas, relancez `aa-logprof` et autorisez les éléments manquants :
```bash
aa-logprof
```
_Parfois, après un redémarrage du serveur, le service concerné par le renforcement peut ne plus fonctionner. Cela est dû à d'autres nouveaux éléments qu'il faudra inscrire dans le fichier de règle. 

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

## Déploiement Docker :

Pour déployer l'application Webzine nous demandons aux développeurs de déposer le projet dans notre repositories de Docker Hub. 

Sur notre machine Webzine Docker : 

    docker pull quentin5821/webzinewebapplication:latest

Cela récupére l'image Docker. 

Maintenant nous exécutons la commande suivante : 

    docker run -d -p 80:80 quentin5821/webzinewebapplication:latest

Maintenant sur notre navigateur : 

    http://192.168.20.253/titre?IdTitre=1#
    http://webzine-g2.g1

Cela fonctionne ! 

## Configuration de SSH :

Création de l'utilisateur sur toutes les VMs :

    adduser quentin

Dans /etc/sudoers : 

    quentin ALL=(ALL:ALL) ALL

Dans /etc/ssh/sshd_config :

    PermitRootLogin=no
    PasswordAuthentication no

Sur notre PC : 

    ssh-keygen -t rsa

Puis :

    ssh-copy-id quentin@IPDELAVM

On redémarre le service SSH :

    systemctl restart sshd

La configuration de SSH est terminée. 

## Configuration de Fail2ban :


Nous téléchargeons le paquet :

    apt install fail2ban 

Copie du fichier Jail.conf :

    cp /etc/fail2ban/jail.conf /etc/fail2ban/jail.local

Modification du "jail.local" :

    [DEFAULT]
    ignoreip = 
    bantime = 21600
    findtime = 300
    maxretry = 3
    banaction = iptables-multiport
    backend = systemd

	[sshd]
	enabled = true

Nous redémarrons le service : 

    systemctl restart fail2ban

Nous pouvons nous connecter via SSH : 

    ssh quentin@IPDELAVM

Si nous loupons trois fois la saisie du mot de passe, fail2ban nous banne ! 


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
