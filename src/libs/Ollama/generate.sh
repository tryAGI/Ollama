#!/usr/bin/env bash
set -euo pipefail

if dotnet tool list --global | grep -q '^autosdk\.cli '; then
  dotnet tool update --global autosdk.cli --prerelease
else
  dotnet tool install --global autosdk.cli --prerelease
fi

curl -fsSL https://raw.githubusercontent.com/ollama/ollama/main/docs/openapi.yaml -o openapi.yaml

if ! command -v yq >/dev/null 2>&1; then
  echo "yq is required to patch the downloaded OpenAPI spec" >&2
  exit 1
fi

for key in \
  total_duration \
  load_duration \
  prompt_eval_duration \
  eval_duration \
  total \
  completed \
  size
do
  yq -i '
    (
      .. |
      select(tag == "!!map" and has("'"$key"'")) |
      .'"$key"' |
      select(.type == "integer")
    ).format = "int64"
  ' openapi.yaml
done

rm -rf Generated

# Official upstream spec:
# https://raw.githubusercontent.com/ollama/ollama/main/docs/openapi.yaml
# Ollama returns nanosecond durations and byte counts that exceed Int32.
# The official spec currently declares these as plain `integer`, so we widen
# those fields to `int64` locally before generation.
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
