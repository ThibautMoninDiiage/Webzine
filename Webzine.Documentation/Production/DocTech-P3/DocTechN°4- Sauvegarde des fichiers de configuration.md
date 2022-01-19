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

