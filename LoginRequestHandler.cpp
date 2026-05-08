#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"
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
    m_handlerFactory.changeRequestHandler(&res, m_handlerFactory.createMenuRequestHanlder());// a safe change of the handlers
    LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);

    // get the stuts from the login manger
    LoginStatus status = m_handlerFactory.getLoginManager().login(userRequest.userName, userRequest.password,reqInfo.userSocket);

    LoginResponse response;

    if (status == LOGIN_SUCCESS)
    {
        response.status = 1;
    }
    else
    {
        response.status = 0;
        m_handlerFactory.changeRequestHandler(&res, this);// a safe change of the handlers

        std::cout << "Login failed for user: " << userRequest.userName << ", Status: " << m_handlerFactory.getLoginManager().getLoginStatus(status) << std::endl;
    }

    res.response = JsonResponsePacketSerializer::serializeResponse(response);
    return res;
}

RequestResult LoginRequestHandler::signup(const RequestInfo& reqInfo)
{
	RequestResult res;
    m_handlerFactory.changeRequestHandler(&res, m_handlerFactory.createLoginRequestHandler());// a safe change of the handlers

	SignupRequest userRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(reqInfo.buff);
	std::cout << "name: " + userRequest.userName + " password: " + userRequest.password + " email: " + userRequest.email << std::endl;

    // get the stuts from the login manger
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