npm install -g grpc-tools
grpc_tools_node_protoc --js_out=import_style=commonjs,binary:./ --grpc_out=./ --plugin=protoc-gen-grpc=`which grpc_tools_node_protoc_plugin` realtyService.proto
grpc_tools_node_protoc --js_out=import_style=commonjs,binary:./ --grpc_out=./ --plugin=protoc-gen-grpc=`which grpc_tools_node_protoc_plugin` realtyServiceTypes.proto