#pragma once

#include "IDatabase.h"
#include "LoginManager.h"

// because i have loop of calling of librarys we need to do Forward Declarations 
class LoginRequestHandler;
class MenuRequestHandler;
class IRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDatabase* database);
	~RequestHandlerFactory();

	LoginRequestHandler* createLoginRequestHandler();
	MenuRequestHandler* createMenuRequestHanlder();
	void changeRequestHandler(RequestResult* res, IRequestHandler*& reqHandler);


	LoginManager& getLoginManager();

private:
	LoginManager m_loginManager;
};