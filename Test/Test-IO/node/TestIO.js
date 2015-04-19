var fs = require('fs');
var LineStream = require('byline').LineStream;
var Transform = require('stream').Transform;
var inputFilename = process.argv[2];
var outputFilename = 'res.txt';
if (!inputFilename || !outputFilename) process.exit(1);
var input = fs.createReadStream(inputFilename);
var output = fs.createWriteStream(outputFilename);
var lineStream = new LineStream();

require('util').inherits(Transformer, Transform);
function Transformer() {
    if (!(this instanceof Transformer)) return new Transformer();
    Transform.call(this);
}

Transformer.prototype._transform = function(line, enc, callback) {
    line = line.toString().replace("Tellus", "Terra").replace("tellus", "terra") + '\n';
    return callback(null, line);
};

input.pipe(lineStream).pipe(new Transformer()).pipe(output);
