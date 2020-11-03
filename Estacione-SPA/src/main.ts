// A aplicação precisa ser inicializada em tempo de execução para iniciar o processo de renderização
// Quando a aplicação estiver construída ele irá olhar para main.ts como um 1º conjunto de instruções

// Importa algumas dependências
import { enableProdMode } from '@angular/core';

// platformBrowserDynamic - é utilizado para informar o Angular qual módulo está sendo carregado (neste caso AppModule)
// Nesse ponto é onde o código começa a ser executado
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

// Importa dependência AppModule
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

// Se environment.production estiver habilitado, irá desligar o modo de desenvolvedor e habilitar o modo de produção
if (environment.production) {
  enableProdMode();
}

// Inicializa o AppModule
platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
