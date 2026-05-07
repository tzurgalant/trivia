#pragma once


#include <WinSock2.h>
#include <Windows.h>
#include "mutex"
#include <queue>
#include <exception>
#include "Communicator.h"
#include "RequestHandlerFactory.h"
#include "SqliteDatabase.h"
class Server
{
public:
	Server();
	~Server();
	void run();
	void shutdown();

private:
	IDatabase* m_database;
	RequestHandlerFactory m_handleFactory;
	Communicator m_communicator; 
	
};
