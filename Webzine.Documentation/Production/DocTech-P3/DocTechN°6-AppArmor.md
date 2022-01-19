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

