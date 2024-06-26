﻿using Domain;
using System.ComponentModel;

namespace Performance
{
	public class PlainUseCase : UseCase
	{
		public override void Run()
		{
			var logger = new Logger();

			var app = new WebService(
				new Authenticator(
					new Logger(),
					new ErrorHandler(
						logger
					),
					new Database(
						new Logger(),
						new ErrorHandler(
							logger
						)
					)
				),
				new StockQuote(
					new Logger(),
					new ErrorHandler(
						logger
					),
					new Database(
						new Logger(),
						new ErrorHandler(
							logger
						)
					)
				)
			);

			app.Execute();
		}
	}
}
