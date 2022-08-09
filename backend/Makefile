run-app:
	docker kill smartschool-database smartschool-api
	docker rmi postgres smartschool-api
	docker-compose -f ./docker-compose.yml up -d

kill-app:
	docker-compose down

run-database:
	docker-compose up -d db
	
run-api:
	docker-compose up -d api-dev
	
add-migration:
	@read -p "Nome da migration (ex: TipoTabelaMotivo) : " table \
	&& dotnet ef --startup-project ./SmartSchool.WebApi migrations add $${table}

remove-migration:
	dotnet ef --startup-project ./SmartSchool.WebApi migrations remove

update-database:
	@echo "Você revisou a migration antes de enviar?"
	@read -p "[Enter para confirmar || CTRL + C para cancelar]" reponse;
	dotnet ef --startup-project ./SmartSchool.WebApi database update