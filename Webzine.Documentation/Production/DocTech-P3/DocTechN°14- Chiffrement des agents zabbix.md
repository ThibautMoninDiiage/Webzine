# Chiffrement des agents zabbix :

A effectuer sur chaque hôte :

On commence par configurer sur le front web Zabbix,  `Configuration`  ➔ Hosts ➔ {votreMachine} ➔ Encryption.  

Modifiez les champs comme ci-dessous :  

Connections to host:  `[PSK]`  
Connections from host: [X] PSK  
PSK identity:  `nom`  
PSK:af8ced32dfe8714e548694e2d29e1a14ba6fa13f216cb35c19d0feb1084b0429

Sur la machine : 

    nano /etc/zabbix/zabbix_agentd.conf

Nous modifions :

    Server=127.0.0.1  
    TLSConnect=psk  
    TLSAccept=psk  
    #Je choisis un nom pour identifier ma clef, utile dans l'interface Zabbix
    TLSPSKIdentity=PSK 001
    TLSPSKFile=/etc/zabbix/zabbix_agentd.psk

Puis :

    nano /etc/zabbix/zabbix_agentd.psk

On insère la clé : 

`af8ced32dfe8714e548694e2d29e1a14ba6fa13f216cb35c19d0feb1084b0429`

On peut changer les droits :

    chown -R zabbix.zabbix /etc/zabbix/zabbix_agentd.psk

Puis on redémarre le service :

    systemctl enable zabbix-agent && systemctl restart zabbix-agent && systemctl status zabbix-agent

On doit stopper firewall :

    systemctl stop firewalld

Une fois que tout est vert dans zabbix, on peut démarrer le service :

    systemctl start firewalld



