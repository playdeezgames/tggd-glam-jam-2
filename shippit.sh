rm -rf ./pub-html
dotnet publish ./src/TGGDGlamJam2/TGGDGlamJam2.csproj -o ./pub-html -c Release 
rm -f ./pub-html/*.pdb
butler push pub-html/wwwroot thegrumpygamedev/gummies-of-splorr:html
