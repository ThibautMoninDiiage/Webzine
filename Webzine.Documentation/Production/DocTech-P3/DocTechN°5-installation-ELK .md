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