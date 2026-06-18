const fs = require("fs");
const path = require("path");

let input = "";

process.stdin.on("data", (chunk) => {
input += chunk;
});

process.stdin.on("end", () => {
try {
const data = JSON.parse(input);

} catch (error) {

  process.exit(1);
}
});
