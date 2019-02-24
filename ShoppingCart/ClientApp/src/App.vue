<template>
    <div id="app">
        <img alt="Vue logo" src="./assets/cart_large.png">
        <Products msg="Welcome to VueCart" />
        <ShoppingCart />
    </div>
</template>

<script>
    import Products from './components/Products.vue'   
    import ShoppingCart from './components/ShoppingCart.vue'

    export default {
        name: 'app',
        components: {
            Products,
            ShoppingCart
        }
    }
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #2c3e50;
        margin-top: 60px;
    }
</style>
