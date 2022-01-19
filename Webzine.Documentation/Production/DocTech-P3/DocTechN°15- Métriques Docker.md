# Métriques Docker :

Sur notre machine Docker :

    wget https://repo.zabbix.com/zabbix/5.2/debian/pool/main/z/zabbix-release/zabbix-release_5.2-1+debian10_all.deb 
    dpkg -i zabbix-release_5.2-1+debian10_all.deb 
    apt update

On installe l'agent2 : 

    apt install zabbix-agent2

On n'arrête l'ancien agent car il ne fonctionnera plus :

    systemctl stop zabbix-agent

Nous redémarons notre service :

    systemctl restart zabbix-agent

Nous allons dans le dossier : 

    nano /etc/zabbix/zabbix_agent2.conf

Nous mettons l'IP de Zabbix dans "Server" et "Server Active" et nous changeons le nom "Hostname" 

Nous exécutons la commande suivante :

    usermod -a -G docker zabbix

Cela corespond à l'ajout de docker au groupe Zabbix. 

Nous redémarons notre service :

    systemctl restart zabbix-agent

Enfin sur les hôtes dans l'interface de Zabbix nous ajoutons le template "Template App Docker" sur nos deux machines virtuelles contenant docker. 

Les données remontent en 3 min. 

