#include "LoginRequestHandler.h"
#include "JsonRequestPacketDeserializer.h"
#include "JsonResponsePacketSerializer.h"


LoginRequestHandler::LoginRequestHandler(RequestHandlerFactory& handlerFactory) :m_handlerFactory(handlerFactory)
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
	return reqInfo.id == LoginCmd ? login(reqInfo) : signup(reqInfo);
}

RequestResult LoginRequestHandler::login(const RequestInfo& reqInfo)
{
    RequestResult res;
    LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);

    // 2. קריאה ל-Manager ושמירת הסטטוס שחזר
    LoginStatus status = m_handlerFactory.getLoginManager().login(userRequest.userName, userRequest.password);

    LoginResponse response;

    if (status == LOGIN_SUCCESS)
    {
        response.status = 1;
    }
    else
    {
        response.status = 0;
        res.newHandler = this;

        std::cout << "Login failed for user: " << userRequest.userName << ", Status: " << m_handlerFactory.getLoginManager().getLoginStatus(status) << std::endl;
    }

    res.response = JsonResponsePacketSerializer::serializeResponse(response);
    return res;
}

RequestResult LoginRequestHandler::signup(const RequestInfo& reqInfo)
{
	RequestResult res;
	res.newHandler = m_handlerFactory.createLoginRequestHandler();

	SignupRequest userRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(reqInfo.buff);
	std::cout << "name: " + userRequest.userName + " password: " + userRequest.password + " email: " + userRequest.email << std::endl;

    // 2. קריאה ל-Manager ושמירת הסטטוס שחזר
    SignupStatus status = m_handlerFactory.getLoginManager().sign_up(userRequest.userName, userRequest.password, userRequest.email);

    SignupResponse response;// create a response for the user

    if (status == SIGNUP_SUCCESS)
    {
        response.status = 1;
    }
    else
    {
        response.status = 0;
        res.newHandler = this;

        std::cout << "Login failed for user: " << userRequest.userName << ", Status: " << m_handlerFactory.getLoginManager().getSignupStatus(status) << std::endl;
    }

	res.response = JsonResponsePacketSerializer::serializeResponse(response);
	return res;
}