import Vue from 'vue'
import App from './App.vue'

import PaymentForm from './components/PaymentForm.vue'
import ProductList from './components/ProductList.vue'
import Cart from './components/Cart.vue'

Vue.component('PaymentForm', PaymentForm)
Vue.component('ProductList', ProductList)
Vue.component('Cart', Cart)

Vue.filter('currency', amount => {
  return '$' + parseFloat(amount).toFixed(2);
});

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')