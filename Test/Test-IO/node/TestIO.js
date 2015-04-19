var fs = require('fs');
var content = fs.readFileSync("../DumpFile/dump.txt", 'utf-8');
content = content.split('\n');
for (var i = 0; i < content.length; i++) {
  content[i] = content[i].replace("Tellus", "Terra");
  content[i] = content[i].replace("tellus", "terra");
}
fs.writeFileSync("res.txt", content.join('\n'));
