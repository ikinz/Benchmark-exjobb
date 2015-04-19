var LineByLineReader  = require("line-by-line"),
    fs                = require("fs"),
    lr                = new LineByLineReader(process.argv[2]);

lr.on('error', function (err) {
  console.log("Error " + err);
});

lr.on('line', function (line) {
  line = line.replace("Tellus", "Terra");
  line = line.replace("tellus", "terra");
  fs.appendFileSync("res.txt", line.toString() + "\n");
});

lr.on('end', function () {

});
