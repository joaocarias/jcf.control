<script setup>
import Button from 'primevue/button';
import Card from 'primevue/card';
import InputText from 'primevue/inputtext';
import Textarea from 'primevue/textarea';
</script>
  
  <template>
  <div class="landing-page">
    <!-- Header -->
    <div class="header flex justify-between align-items-center p-4 shadow-2">
      <div class="logo text-2xl font-bold text-primary">JCF Control App</div>
      <div class="menu flex gap-4">
        <Button label="Home" link />
        <Button label="Funcionalidades" link />
        <Button label="Preços" link />
        <Button label="Contato" link />
      </div>
    </div>

    <!-- Hero Section -->
    <div class="hero flex flex-column md:flex-row align-items-center justify-content-between p-8">
      <div class="text-section">
        <h1 class="text-5xl font-bold mb-4">
          Controle suas <span class="text-primary">Finanças</span> de forma simples
        </h1>
        <p class="text-lg mb-6">
          O <strong>JCF Control App</strong> é a ferramenta web ideal para organizar entradas, saídas e ter total controle do seu dinheiro.
        </p>
        <Button label="Comece Agora" class="mr-3" />
        <Button label="Saiba Mais" severity="secondary" link />
      </div>
      <div class="image-section">
        <img src="https://primefaces.org/cdn/primevue/images/landing/hero.svg" alt="Finance Control" class="w-full md:w-30rem" />
      </div>
    </div>

    <!-- Funcionalidades -->
    <div class="features p-8">
      <h2 class="text-3xl font-bold text-center mb-6">Funcionalidades</h2>
      <div class="grid">
        <div class="col-12 md:col-4">
          <Card>
            <template #title>Gestão de Entradas e Saídas</template>
            <template #content>
              <p>Registre cada entrada e saída de dinheiro de forma rápida e eficiente.</p>
            </template>
          </Card>
        </div>
        <div class="col-12 md:col-4">
          <Card>
            <template #title>Relatórios Detalhados</template>
            <template #content>
              <p>Visualize relatórios para entender onde você está gastando e onde pode economizar.</p>
            </template>
          </Card>
        </div>
        <div class="col-12 md:col-4">
          <Card>
            <template #title>Dashboard Inteligente</template>
            <template #content>
              <p>Acompanhe seu saldo, fluxo de caixa e metas financeiras em tempo real.</p>
            </template>
          </Card>
        </div>
      </div>
    </div>

    <!-- Plano/Preços -->
    <div class="pricing p-8 bg-primary-50">
      <h2 class="text-3xl font-bold text-center mb-6">Planos</h2>
      <div class="flex flex-column md:flex-row justify-content-center gap-5">
        <Card class="w-20rem">
          <template #title>Gratuito</template>
          <template #content>
            <p>Ideal para uso pessoal.</p>
            <ul>
              <li>- Até 50 registros</li>
              <li>- Dashboard básico</li>
              <li>- Suporte via e-mail</li>
            </ul>
          </template>
          <template #footer>
            <Button label="Começar" />
          </template>
        </Card>

        <Card class="w-20rem">
          <template #title>Profissional</template>
          <template #content>
            <p>Perfeito para empresas e profissionais.</p>
            <ul>
              <li>- Registros ilimitados</li>
              <li>- Dashboard avançado</li>
              <li>- Suporte prioritário</li>
            </ul>
          </template>
          <template #footer>
            <Button label="Assinar" />
          </template>
        </Card>
      </div>
    </div>

    <!-- Contato -->
    <div class="contact p-8">
      <h2 class="text-3xl font-bold text-center mb-6">Fale Conosco</h2>
      <div class="flex justify-content-center">
        <div class="w-full md:w-6">
          <div class="p-fluid">
            <div class="field">
              <label for="name">Nome</label>
              <InputText id="name" />
            </div>
            <div class="field">
              <label for="email">Email</label>
              <InputText id="email" />
            </div>
            <div class="field">
              <label for="message">Mensagem</label>
              <Textarea id="message" rows="4" />
            </div>
            <Button label="Enviar Mensagem" />
          </div>
        </div>
      </div>
    </div>

    <!-- Footer -->
    <div class="footer p-4 text-center bg-primary text-white">
      <p>&copy; 2025 JCF Control App - Todos os direitos reservados.</p>
    </div>
  </div>
</template>



<style scoped>
.landing-page {
  font-family: 'Inter', sans-serif;
}

.hero {
  background: linear-gradient(135deg, var(--primary-color) 0%, #ffffff 100%);
  border-radius: 1rem;
}

.image-section img {
  border-radius: 1rem;
}

.features .p-card {
  transition: transform 0.3s ease;
}

.features .p-card:hover {
  transform: translateY(-5px);
}

.footer {
  border-top: 1px solid rgba(255, 255, 255, 0.2);
}
</style>


