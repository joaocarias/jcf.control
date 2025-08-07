import { createI18n } from 'vue-i18n';
import ptBR from './locales/pt-BR';

const messages = {
  'pt-BR': ptBR
};

const i18n = createI18n({
  locale: 'pt-BR',
  fallbackLocale: 'pt-BR',
  messages
});

export default i18n;
