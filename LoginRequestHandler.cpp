#include "LoginRequestHandler.h"
#include "JsonRequestPacketDeserializer.h"


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
		LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);
		std::cout << "name: " + userRequest.userName + " password: " + userRequest.password << std::endl;
	}
	else
	{
		SignupRequest userRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(reqInfo.buff);
		std::cout << "name: " + userRequest.userName + " password: " + userRequest.password + " email: " + userRequest.email << std::endl;

	}
	res.newHandler = nullptr;
	return res;
}
