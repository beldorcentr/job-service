# Job service

Recurrent tasks with web interface as a service

## Description

Dotnet template for tasks service. Hosted as windows service, execute recurrent tasks, allowing to queue tasks with HTTP requests and from web interface.

## Development

Debug build run as console application. In browser open /hangfire to see Hangfire Dashboard. Send HTTP POST on /api/makefoo to queue job. Job CRONs in appsettings.json tasks:cron.

### Create nuget temlate

```
nuget pack Package.nuspec
dotnet new -i Bdc.JobService.1.0.0.nupkg
dotnet new bdcjobservice
```

## TODO

* Logging

* Nuget package

* Documentation
