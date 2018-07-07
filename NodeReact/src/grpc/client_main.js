var messages = require('./realtyService_pb');
var services = require('./realtyService_grpc_pb');
const url = require('url');
const http = require('http');
var grpc = require('grpc');
var client;

const app = http.createServer((request, response) => {
  var query;  
  response.writeHead(200, {"Content-Type": "text/html"});
  response.write(`&lt;h1&gt;The city you are in is 00.&lt;/h1&gt;`);
  response.end();
});

app.listen(3000);
console.log("Server started at port 3000")

function main() {
	
  initialize();
  
  
  var request = new messages.RealtyListRequest();
  var realtyType = 1;
  request.setType(realtyType);
  
  var call = client.getRealtyList(request, function(err, response) {
	  var res = response.toObject();
	console.log(res.realtiesList[1].message);
  });
}

//main();

function initialize(){
	client = new services.DowntownRealtyClient('localhost:2323',
                                          grpc.credentials.createInsecure());
}