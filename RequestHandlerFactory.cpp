#include "RequestHandlerFactory.h"
#include "LoginRequestHandler.h"



RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database)
{

}
RequestHandlerFactory::~RequestHandlerFactory()
{

}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}
LoginManager& RequestHandlerFactory::getLoginManager() 
{
	return m_loginManager;
}