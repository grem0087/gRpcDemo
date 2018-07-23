var messages = require('./src/grpc/realtyService_pb');
var services = require('./src/grpc/realtyService_grpc_pb');
const url = require('url');
const http = require('http');
var grpc = require('grpc');
var client;

const app = http.createServer((request, response) => {	
  var query;  
  initialize();

  pathName= url.parse(request.url).pathname;
  query= pathName.split('/').slice(1);
  realtyIndex = query[1];
  path = query[0];
  
  if (path == 'realty' && realtyIndex >=0 &&  realtyIndex<4) {
        var request = new messages.RealtyListRequest();
		  request.setType(realtyIndex);
		  
		  var call = client.getRealtyList(request, function(err, responseGrpc) {
			  var responseGrpcObject = responseGrpc.toObject();
			  response.writeHead(200, {"Content-Type": "text/html"});
			  for(let i=0;i<responseGrpcObject.realtiesList.length; i++){
				response.write("<h3>Id:"+responseGrpcObject.realtiesList[i].id+responseGrpcObject.realtiesList[i].topic+"</h3>"+responseGrpcObject.realtiesList[i].message + "<br><br>");  
			  }
			  
			  response.end();
		  });
    }else{
  response.writeHead(200, {"Content-Type": "text/html"});
  response.write(`<h1>All your base belong us.</h1>`);
  response.end();
	}
});

app.listen(3000);
console.log("Server started at port 3000")

function initialize(){
	client = new services.DowntownRealtyClient('localhost:2323',
                                          grpc.credentials.createInsecure());
}

