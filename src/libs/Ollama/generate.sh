dotnet tool install --global openapigenerator.cli --prerelease
rm -rf Generated
# curl -o ../../../docs/openapi.yaml https://raw.githubusercontent.com/davidmigloz/langchain_dart/main/packages/ollama_dart/oas/ollama-curated.yaml
# dotnet run --project ../../helpers/FixOpenApiSpec ../../../docs/openapi.yaml
# if [ $? -ne 0 ]; then
#   echo "Failed, exiting..."
#   exit 1
# fi
oag generate ../../../docs/openapi.yaml \
  --namespace Ollama \
  --clientClassName OllamaApiClient \
  --targetFramework net8.0 \
  --output Generated