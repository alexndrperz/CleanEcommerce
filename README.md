# CleanEcomm - Clean Architecture eCommerce Project

Proyecto de eCommerce implementado con Clean Architecture, Entity Framework Core y SQL Server.

## Estructura del Proyecto

```
CleanEcomm/
├── CleanEcomm.Domain/              # Capa de Dominio
│   ├── Entities/                  # Entidades del dominio
│   ├── ValueObjects/              # Objetos de valor
│   └── Interfaces/                # Interfaces de repositorio
├── CleanEcomm.Application/         # Capa de Aplicación
│   ├── DTOs/                      # Objetos de transferencia de datos
│   ├── Interfaces/                # Contratos de servicios
│   └── Services/                  # Lógica de aplicación
├── CleanEcomm.Infrastructure/      # Capa de Infraestructura
│   ├── Data/                      # DbContext y configuración EF
│   ├── Repositories/              # Implementaciones de repositorio
│   └── Extensions/                # Extensiones de DI
└── CleanEcomm.API/               # Capa de Presentación (API)
    ├── Controllers/               # Endpoints REST
    ├── Extensions/                # Extensiones de configuración
    └── appsettings.json          # Configuración
```

## Requisitos Previos

- .NET 10.0 o superior
- Docker y Docker Compose
- SQL Server 2022 (a través de Docker)

## Configuración e Instalación

### 1. Levantar SQL Server con Docker

```bash
docker-compose up -d
```

Este comando inicia un contenedor de SQL Server 2022 con:
- **Usuario**: sa
- **Contraseña**: Admin@1234
- **Puerto**: 1433
- **Base de datos**: CleanEcommDb (se crea automáticamente)

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Crear y aplicar migraciones

```bash
# Ir a la carpeta de la API
cd CleanEcomm.API

# Crear una migración inicial
dotnet ef migrations add InitialCreate --startup-project . --project ../CleanEcomm.Infrastructure

# Las migraciones se aplican automáticamente al iniciar la aplicación
```

### 4. Ejecutar la aplicación

```bash
cd CleanEcomm.API
dotnet run
```

La API estará disponible en: `https://localhost:5001` o `http://localhost:5000`

## Swagger/OpenAPI

Una vez que la aplicación está corriendo, accede a la documentación interactiva en:
```
https://localhost:5001/swagger
```

## Endpoint de Prueba

- **GET** `/api/health` - Verificar que el servicio está activo

## Comandos Entity Framework útiles

```bash
# Crear una migración
dotnet ef migrations add NombreMigracion --startup-project CleanEcomm.API --project CleanEcomm.Infrastructure

# Actualizar la base de datos
dotnet ef database update --startup-project CleanEcomm.API

# Ver migraciones pendientes
dotnet ef migrations list --startup-project CleanEcomm.API

# Eliminar la última migración
dotnet ef migrations remove --startup-project CleanEcomm.API
```

## Detener SQL Server

```bash
docker-compose down
```

Para mantener los datos:
```bash
docker-compose down -v  # Elimina también los volúmenes
```

## Estructura de Capas

### Domain Layer
- Contiene la lógica de negocio central
- Independiente de cualquier framework
- Define interfaces de repositorio

### Application Layer
- Contiene servicios de aplicación
- DTOs para transferencia de datos
- Interfaces de servicios

### Infrastructure Layer
- Implementaciones de repositorio
- DbContext y configuración de EF
- Inyección de dependencias

### API Layer
- Controladores REST
- Configuración de la aplicación
- Middleware personalizado

## Patrones Implementados

- **Repository Pattern**: Abstracción del acceso a datos
- **Dependency Injection**: Inyección de dependencias con .NET Core
- **Entity Framework Core**: ORM para acceso a datos
- **Minimal API**: Enfoque moderno de APIs
- **Clean Architecture**: Separación de capas

## Próximos Pasos

1. Crear entidades de negocio en `CleanEcomm.Domain/Entities`
2. Implementar servicios en `CleanEcomm.Application/Services`
3. Crear controladores en `CleanEcomm.API/Controllers`
4. Definir configuraciones de EF en `ApplicationDbContext`

## Notas

- Las migraciones se aplican automáticamente al iniciar la aplicación
- La conexión a la base de datos está configurada en `appsettings.json`
- El contenedor de SQL Server se reinicia automáticamente
