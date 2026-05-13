#include "LoginRequestHandler.h"
#include "MenuRequestHandler.h"

RequestHandlerFactory::RequestHandlerFactory(IDatabase* database) : m_loginManager(database)
{

}
RequestHandlerFactory::~RequestHandlerFactory()
{

}

void RequestHandlerFactory::changeRequestHandler(RequestResult* res, IRequestHandler* reqHandler)
{
	if (res->newHandler != nullptr)
	{
		if( reqHandler != nullptr)
		{
			delete reqHandler;
		}
		reqHandler = res->newHandler;
	}
}


MenuRequestHandler* RequestHandlerFactory::createMenuRequestHanlder()
{
	return new  MenuRequestHandler(*this);
}

LoginRequestHandler* RequestHandlerFactory::createLoginRequestHandler()
{
	return new LoginRequestHandler(*this);
}
LoginManager& RequestHandlerFactory::getLoginManager() 
{
	return m_loginManager;
}