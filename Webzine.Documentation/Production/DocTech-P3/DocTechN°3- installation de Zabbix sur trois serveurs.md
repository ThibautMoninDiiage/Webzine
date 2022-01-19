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

