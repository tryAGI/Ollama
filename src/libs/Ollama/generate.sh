dotnet tool install --global openapigenerator.cli --prerelease
rm -rf Generated
curl -o openapi.yaml https://raw.githubusercontent.com/davidmigloz/langchain_dart/main/packages/ollama_dart/oas/ollama-curated.yaml
dotnet run --project ../../helpers/FixOpenApiSpec openapi.yaml
if [ $? -ne 0 ]; then
 echo "Failed, exiting..."
 exit 1
fi
oag generate openapi.yaml \
  --namespace Ollama \
  --clientClassName OllamaApiClient \
  --targetFramework net8.0 \
  --output Generated
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