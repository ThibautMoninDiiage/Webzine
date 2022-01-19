# Sur chaque VM :
## Installation de firewalld :

    apt install -y firewalld

## Configuration de firewalld :

    firewall-cmd --new-zone=g2 --permanent
    firewall-cmd --reload

Changement de la zone par défaut : 

    firewall-cmd --set-default-zone=G2
    firewall-cmd --reload

Sur la machine SRVDEB11ZABBIX :

    firewall-cmd --add-service=http --permanent
    firewall-cmd --add-service=ssh --permanent
    firewall-cmd --add-service=zabbix-agent --permanent
    firewall-cmd --add-service=zabbix-server --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVDEB11FRONT

    firewall-cmd --add-service=http --permanent
    firewall-cmd --add-service=zabbix-agent --permanent
     firewall-cmd --add-service=ssh --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVDEB11SGBD 

    firewall-cmd --add-service=ssh --permanent
    firewall-cmd --add-service=postgresql --permanent
    firewall-cmd  --add-port=5432/tcp --permanent
    firewall-cmd --add-service=zabbix-agent  --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVDEB11BACKUP 

    firewall-cmd --add-service=ssh --permanent
    firewall-cmd --add-service=zabbix-agent --permanent
    firewall-cmd --add-service=rsyncd --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVDEBELK : 

    firewall-cmd --add-service=elasticsearch --permanent
    firewall-cmd --add-service=ssh --permanent
    firewall-cmd --add-service=zabbix-agent --permanent
    firewall-cmd --add-port=8000/tcp --permanent
    firewall-cmd --add-port=9443/tcp --permanent
    firewall-cmd --add-port=5000/tcp --permanent
    firewall-cmd --add-port=5044/tcp --permanent
    firewall-cmd --add-port=9600/tcp --permanent
    firewall-cmd --add-port=5601/tcp --permanent
    firewall-cmd --add-port=9200/tcp --permanent
    firewall-cmd --add-service=http --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVNGINXPROX :

    firewall-cmd --zone=internal --add-masquerade --permanent
    firewall-cmd --add-port=5601/tcp --permanent
    firewall-cmd --add-service=elasticsearch --permanent
    firewall-cmd --add-service=http --permanent
    firewall-cmd --add-service=zabbix-agent --permanent
    firewall-cmd --add-service=ssh --permanent
    firewall-cmd  --add-port=5601/tcp --permanent
    firewall-cmd  --add-port=10050/tcp --permanent
    firewall-cmd  --add-port=5432/tcp --permanent

On reload le service : 

    firewall-cmd --reload

Sur la machine SRVBACKWEBZINE

    firewall-cmd --add-service=zabbix-agent --permanent
    firewall-cmd --add-service=ssh --permanent
    firewall-cmd --add-service=postgresql --permanent
    firewall-cmd --add-service=http --permanent
    
Fin de la configuration. 
