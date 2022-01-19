VMNGINXREVERSE : 

   

     root@SRVNGINXPROX:/# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: elasticsearch http ssh zabbix-agent
    
    ports: 5601/tcp 9200/tcp
    
    protocols:
    
    forward: no
    
    masquerade: yes
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:


VMSRVDEBELK :

    root@SRVDEBELK:/# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: elasticsearch http ssh zabbix-agent
    
    ports: 8000/tcp 9443/tcp 5000/tcp 5044/tcp 9600/tcp 5601/tcp 9200/tcp 180/tcp
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

VMSRVDEB11 :

    root@SRVDEB11ZABBIX:/# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: http ssh zabbix-agent zabbix-server
    
    ports: 9200/tcp 5601/tcp
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

VMSRVDEB11SGBDZABBIX :

    root@SRVDEB11SGBD:/# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: postgresql ssh zabbix-agent
    
    ports: 5432/tcp
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

SRVDEBFRONTZABBIX :

    root@SRVDEB11FRONT:/home/quentin# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: http ssh zabbix-agent
    
    ports: 9200/tcp
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

SRVWEBZINE : 

    root@SRVBACKWEBZINE:/# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: http https postgresql ssh zabbix-agent
    
    ports:
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

SRVBACKUP : 

    root@SRVDEB11BACKUP:/home/quentin# firewall-cmd --info-zone=g2
    
    g2
    
    target: default
    
    icmp-block-inversion: no
    
    interfaces:
    
    sources:
    
    services: rsyncd ssh zabbix-agent
    
    ports: 873/tcp
    
    protocols:
    
    forward: no
    
    masquerade: no
    
    forward-ports:
    
    source-ports:
    
    icmp-blocks:
    
    rich rules:

