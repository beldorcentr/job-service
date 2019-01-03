# Job service

Recurrent tasks with web interface as a service

## Description

Dotnet template for tasks service. Hosted as windows service, execute recurrent tasks, allowing to queue tasks with HTTP requests and from web interface.

Service use NLog for logging and provide config for Oracle database target (WEB_OFFICE.WEBPKG.addErrorApp).

## Development

Debug build run as console application with api on 5000 port (configurable in appsettings.json). In browser open /hangfire to see Hangfire Dashboard. Send HTTP POST on /api/makefoo to queue job. Job CRONs in appsettings.json tasks:cron.

### Create nuget template

```
nuget pack Package.nuspec
dotnet new -i Bdc.JobService.1.0.0.nupkg
dotnet new bdcjobservice -n AwesomeService
```
