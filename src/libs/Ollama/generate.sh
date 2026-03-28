#!/usr/bin/env bash
set -euo pipefail

dotnet tool install --global autosdk.cli --prerelease

curl -fsSL https://raw.githubusercontent.com/ollama/ollama/main/docs/openapi.yaml -o openapi.yaml

rm -rf Generated
autosdk generate openapi.yaml \
  --namespace Ollama \
  --clientClassName OllamaClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
#openapi-generator generate \
#  -i openapi.yaml \
#  -g csharp \
#  -o generichost \
#  --package-name Ollama \
#  --additional-properties library=generichost,nullableReferenceTypes=true,targetFramework='netstandard2.0;net47;net6.0;net8.0'
#openapi-generator generate \
#  -i openapi.yaml \
#  -g csharp \
#  -o httpclient \
#  --package-name Ollama \
#  --additional-properties library=httpclient,nullableReferenceTypes=true,targetFramework='netstandard2.0;net47;net6.0;net8.0'
