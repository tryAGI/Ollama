dotnet tool install --global openapigenerator.cli --prerelease
rm -rf Generated
# curl -O https://raw.githubusercontent.com/openai/openai-openapi/master/openapi.yaml
# dotnet run --project ../../helpers/FixOpenApiSpec openapi.yaml
# if [ $? -ne 0 ]; then
#   echo "Failed, exiting..."
#   exit 1
# fi
oag generate ../../../docs/openapi.yaml \
  --namespace Ollama \
  --clientClassName OllamaApiClient \
  --targetFramework net8.0 \
  --output Generated