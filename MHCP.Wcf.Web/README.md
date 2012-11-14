Capa de Presentación de Servicios
=================================
Para el uso de WCF, un buen enfoque arquitectónico consiste en poner todo de la implementación en una librería de WCF, y luego, utilizar esta librería en un proyecto de *Aplicación de Servicio WCF* independiente o en un proyecto sin fines de WCF. 

De esta manera, la librería de WCF se puede reutilizar en muchos otros lugares, ya sea por medio de referencias de clases regulares de otra biblioteca no-WCF / proyecto, o utilizando las diferentes estrategias de implementación de WCF ya sea a través del servicio web en IIS, por *WAS*, o *Self Hosted*.


## Criterios de Diseño ##
----------