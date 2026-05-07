#pragma once

#include "IDatabase.h"
#include "LoginManager.h"

// because i have loop of calling of librarys we need to do Forward Declarations 
class LoginRequestHandler;
class IRequestHandler;

class RequestHandlerFactory
{
public:
	RequestHandlerFactory(IDatabase* database);
	~RequestHandlerFactory();

	LoginRequestHandler* createLoginRequestHandler();
	LoginManager& getLoginManager();

private:
	LoginManager m_loginManager;
	IDatabase* m_database;
};