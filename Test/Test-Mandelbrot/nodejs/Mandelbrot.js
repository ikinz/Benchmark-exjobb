var BUFFER_SIZE = 8192;

var size = 600;
var buf = new Array(BUFFER_SIZE);
var bufLen = 0;
var fac;
var shift;

start();

function start() {
    console.log("P4\n" + size + " " + size + "\n");
    for (var y = 0; y < size; y++) {
        computeRow(y);
    }
    console.log(bin2String(buf));
}

function computeRow(y) {
    var bits = 0;
    
    var Ci = (y*fac - 1.0);
    var bufLocal = buf;
    for (var x = 0; x < size; x++) {
        var Zr = 0.0;
        var Zi = 0.0;
        var Cr = (x*fac - 1.5);
        var i = 50;
        var ZrN = 0;
        var ZiN = 0;
        do {
            Zi = 2.0 * Zr * Zi + Ci;
            Zr = ZrN - ZiN + Cr;
            ZiN = Zi * Zi;
            ZrN = Zr * Zr;
        } while (!(ZiN + ZrN > 4.0) && --i > 0);
        
        bits = bits << 1;
        if (i == 0) {
            bits++;
        }
        
        if (x%8 == 7) {
            bufLocal[bufLen++] = bits;
            if (bufLen == BUFFER_SIZE) {
                console.log(bin2String(bufLocal));
                bufLen = 0;
            }
            bits = 0;
        }
    }
    if (shift!=0) {
        bits = bits << shift;
        bufLocal[bufLen++] = bits;
        if (bufLen == BUFFER_SIZE) {
            console.log(bin2String(bufLocal));
            bufLen = 0;
        }
    }
}

function bin2String(array) {
    var result = "";
    for (var i = 0; i < array.length; i++) {
        result += String.fromCharCode(parseInt(array[i], 2));
    }
    return result;
}