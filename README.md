# ¡Hola! 👋 Soy Edgar González

## 💻 Desarrollador Full Stack

Ingeniero de software especializado en el desarrollo de soluciones empresariales de alto rendimiento. Mi enfoque combina conocimientos técnicos sólidos con una visión estratégica para crear aplicaciones que optimizan procesos de negocio y mejoran la experiencia del usuario final.

# SIMPLE API para Facturación Electrónica

API para la generación y procesamiento de documentos tributarios electrónicos (DTE) para el Servicio de Impuestos Internos (SII) de Chile.

## Descripción

Esta API permite la creación, firma y envío de documentos tributarios electrónicos al SII de Chile. Incluye soporte para diferentes tipos de documentos como facturas, boletas, notas de crédito, notas de débito, entre otros.

## Características

- Generación de documentos tributarios electrónicos (DTE)
- Firma electrónica de documentos
- Envío de documentos al SII
- Consulta de estado de documentos
- Manejo de certificados digitales
- Generación de PDF417 para documentos
- Soporte para cesión de documentos
- Generación de libros contables electrónicos

## Requisitos

- .NET Framework 4.8
- Certificado digital válido para firmar documentos

## Dependencias

- Newtonsoft.Json
- iTextSharp
- BouncyCastle

## Estructura del Proyecto

El proyecto está organizado en diferentes carpetas según la funcionalidad:

- **CAFHandler**: Manejo de archivos CAF (Código de Autorización de Folios)
- **Cesion**: Clases para la cesión de documentos
- **DTE**: Motor principal para la generación de documentos
- **Documento**: Clases que representan los diferentes tipos de documentos
- **Enum**: Enumeraciones utilizadas en el proyecto
- **Envio**: Clases para el envío de documentos
- **Helpers**: Funciones de ayuda
- **InformacionElectronica**: Clases para la generación de libros contables
- **PDF417**: Generación de códigos PDF417
- **RCOF**: Reporte de Consumo de Folios
- **Security**: Clases relacionadas con la seguridad
- **WS**: Clases para la comunicación con los servicios web del SII
- **XML**: Esquemas y utilidades XML

## 🛠️ Mi Stack Tecnológico

### Proyectos Actuales

#### Sistema de Producción Ferias Bio Bio
Plataforma empresarial integral para la gestión completa del ciclo de remates ganaderos, desde el ingreso de animales hasta la facturación y control financiero, con integración a sistemas gubernamentales (SAG, SII) y trazabilidad completa.
Stack tecnológico:
- Backend: Visual Basic .NET Framework 4.8 con arquitectura MVC para separación de responsabilidades y mantenimiento optimizado
- Frontend: Windows Forms con Krypton Toolkit para interfaces modernas y responsive adaptadas a entornos empresariales
- Persistencia: SQL Server con procedimientos almacenados y consultas optimizadas para alto rendimiento en transacciones concurrentes
- Reportería avanzada: Microsoft ReportViewer con plantillas RDLC personalizadas para generación dinámica de informes y dashboards analíticos
- Documentación digital: iTextSharp para generación programática de documentos PDF con firma electrónica avanzada
- Trazabilidad: Implementación de ZXing.Net y ThoughtWorks.QRCode para codificación/decodificación de información en códigos QR
- Integración cloud: Microsoft Graph API y Azure Identity para autenticación segura y gestión de identidades
- Serialización de datos: System.Text.Json para procesamiento eficiente de estructuras JSON en comunicaciones con APIs externas
- Seguridad: Implementación de protocolos de encriptación y autenticación multinivel para protección de datos sensibles

#### MECHARV - Sistema de Notas de Pedido
Aplicación móvil multiplataforma para gestión logística de equipos de protección personal (EPP) y repuestos industriales con capacidades avanzadas de sincronización offline y procesamiento en tiempo real.
Stack tecnológico:
- Framework multiplataforma: Flutter para desarrollo cross-platform (iOS/Android) con una única base de código
- Lenguaje: Dart con programación asíncrona y gestión eficiente de estados mediante Provider/Bloc
- Persistencia local: SQLite con Room para almacenamiento estructurado y Hive para caché de alta velocidad
- Sincronización: Arquitectura offline-first con resolución automática de conflictos y sincronización diferencial
- Networking: Dio para comunicaciones HTTP optimizadas con interceptores y manejo avanzado de errores
- UI/UX: Material Design 3 con componentes personalizados y animaciones fluidas optimizadas para rendimiento

#### Sistema de Gestión FANDA
Plataforma web empresarial para administración integral de ventas, convenios y análisis financiero con dashboards interactivos y reportes en tiempo real.
Stack tecnológico:
- Frontend: React.js con TypeScript para interfaces dinámicas y tipado estático que previene errores en tiempo de desarrollo
- Backend: Node.js con Express para APIs RESTful de alto rendimiento y WebSockets para actualizaciones en tiempo real
- Base de datos: PostgreSQL para datos relacionales con optimización de consultas complejas
- Visualización de datos: D3.js y Chart.js para dashboards analíticos interactivos con filtrado dinámico

## 🌱 Actualmente estoy aprendiendo
- Arquitecturas de microservicios: Implementación de servicios distribuidos con Docker, Kubernetes y patrones de comunicación asíncrona
- DevOps y CI/CD: Automatización de pipelines con GitHub Actions, Jenkins y estrategias de despliegue continuo
- Desarrollo móvil avanzado: Arquitecturas limpias en Flutter con inyección de dependencias y testing automatizado

## 💼 Proyectos destacados
- MECHARV - Sistema de Notas de Pedido: Solución móvil empresarial para gestión logística con sincronización offline y procesamiento en tiempo real.
- Sistema de Gestión FANDA: Plataforma web integral para administración de ventas y convenios con análisis financiero avanzado.
- Sistema de Producción Ferias Bio Bio: Solución empresarial completa para la gestión de remates ganaderos con integración a sistemas gubernamentales y trazabilidad end-to-end.
- SIMPLE API para Facturación Electrónica: API para la generación y procesamiento de documentos tributarios electrónicos (DTE) para el SII de Chile.

⭐️ ¡No dudes en contactarme para colaboraciones o consultas profesionales!
