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
    if (reqInfo.id == LoginCmd)
    {
        LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);

        if (m_handlerFactory.getLoginManager().doesUserLogged(userRequest.userName))
        {
            return false;
        }
        return true;
    }
    else if (reqInfo.id == SignupCmd)
    {
        return true;
    }

    return false;
}

RequestResult LoginRequestHandler::handleRequest(const RequestInfo& reqInfo)
{
	return reqInfo.id == LoginCmd ? login(reqInfo) : signup(reqInfo);
}

RequestResult LoginRequestHandler::login(const RequestInfo& reqInfo)
{
    
    RequestResult res;
    res.newHandler = nullptr;//defalut that he not ssuccss to do the login
    LoginRequest userRequest = JsonRequestPacketDeserializer::deserializeLoginRequest(reqInfo.buff);

    // get the status from the login manger
    LoginStatus status = m_handlerFactory.getLoginManager().login(userRequest.userName, userRequest.password,reqInfo.userSocket);
    LoginResponse LoginResponse;

    if (status == LOGIN_SUCCESS)
    {
        LoginResponse.status = 1;
        res.newHandler = m_handlerFactory.createMenuRequestHanlder(m_handlerFactory.getLoginManager().getUserBySocket(reqInfo.userSocket));
        std::cout << "Login success for user: " + userRequest.userName + ", Status: " + m_handlerFactory.getLoginManager().getLoginStatus(status) << std::endl;
    }
    else
    {
        LoginResponse.status = 0;

        res.newHandler = m_handlerFactory.createLoginRequestHandler();
        std::cout << "Login failed for user: " + userRequest.userName + ", Status: " + m_handlerFactory.getLoginManager().getLoginStatus(status) << std::endl;
    }
    res.response = JsonResponsePacketSerializer::serializeResponse(LoginResponse);
    return res;
}

RequestResult LoginRequestHandler::signup(const RequestInfo& reqInfo)
{
	RequestResult res;
    res.newHandler =  nullptr;//defalut that he not ssuccss to do the login

	SignupRequest userRequest = JsonRequestPacketDeserializer::deserializeSignupRequest(reqInfo.buff);
	std::cout << "name: " + userRequest.userName + " password: " + userRequest.password + " email: " + userRequest.email << std::endl;

    // get the stuts from the login manger
    SignupStatus status = m_handlerFactory.getLoginManager().sign_up(userRequest.userName, userRequest.password, userRequest.email);

    SignupResponse signupResponse;// create a response for the user

    if (status == SIGNUP_SUCCESS)
    {
        signupResponse.status = 1;

        res = login(reqInfo);// if success to sign up call the login fucniton 
        std::cout << "signup and Login success for user: " + userRequest.userName + ", Status: " + m_handlerFactory.getLoginManager().getSignupStatus(status) << std::endl;
    }
    else
    {
        signupResponse.status = 0;
        res.newHandler = m_handlerFactory.createLoginRequestHandler();
        std::cout << "Login failed for user: " + userRequest.userName + ", Status: " + m_handlerFactory.getLoginManager().getSignupStatus(status) << std::endl;
    }
    res.response = JsonResponsePacketSerializer::serializeResponse(signupResponse);
	return res;
}