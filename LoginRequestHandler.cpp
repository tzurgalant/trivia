#include "LoginRequestHandler.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"


LoginRequestHandler::LoginRequestHandler()
{ 
}
LoginRequestHandler::~LoginRequestHandler()
{ }

bool LoginRequestHandler::isRequestRelevant(const RequestInfo& reqInfo)
{
	return reqInfo.id == LoginCmd || reqInfo.id == SignupCmd;
}
RequestResult LoginRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	RequestResult res;
	if (reqInfo.id == LoginCmd)
	{
		//get request deadtls whit deserialzer fucniton 
		LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);
		std::cout << "name: " + userRequest.userName + " password: " + userRequest.password << std::endl;



		LoginResponse response;// create a response for the user
		response.status = 1;// asuccess
		
		res.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	else
	{
		SignupRequest userRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(reqInfo.buff);
		std::cout << "name: " + userRequest.userName + " password: " + userRequest.password + " email: " + userRequest.email << std::endl;


		SignupResponse response;// create a response for the user
		response.status = 1;// asuccess

		res.response = JsonResponsePacketSerializer::serializeResponse(response);
	}
	
	res.newHandler = nullptr;
	return res;
}
