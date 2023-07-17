# Build All Dockerfiles and show Size

This tool builds all the Dockerfiles in a directory and then shows their size.

## Usage

```bash
dotnet run path-to-directory
```

Dockerfile substrings can be skipped with `--ignore`.

```bash
dotnet run --ignore nano --ignore windows path-to-directory
```

## Sort images by size

```bash
docker images --filter="reference=dockerfile*" | sort -k7 -h  
```

## Deleting images

```bash
docker rmi -f $(docker images --filter="reference=dockerfile*" -q) 
```
