<template>
    <div class="payment-form">

        <form @submit.prevent="submitForm">
      
            <table>
                <tr>
                    <td colspan="6">
                        <span>Credit Card Info</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <!--<input type="text" id="cardnumber" required name="cardnumber" v-model="cardnumber" placeholder="1111-1111-1111-1111" />-->
                        <input type="text" id="cardnumber" name="cardnumber" v-model="cardnumber" placeholder="1111-1111-1111-1111" />
                    </td>
                </tr>
                <tr>
                    <td colspan="1">
                        <!--<input type="text" id="month" required name="month" v-model="month" placeholder="MM" />-->
                        <input type="text" id="month" name="month" v-model="month" placeholder="MM" />
                    </td>
                    <td colspan="4">
                        <!--<input type="text" id="year" required v-model="year" placeholder="YYYY" />-->
                        <input type="text" id="year" v-model="year" placeholder="YYYY" />
                    </td>
                    <td colspan="1">
                        <!--<input type="text" id="cvv" required v-model="cvv" placeholder="CVV" />-->
                        <input type="text" id="cvv" v-model="cvv" placeholder="CVV" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <span>Billing Address</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <!--<input type="text" required v-model="firstname" placeholder="First Name" />-->
                        <input type="text" v-model="firstname" placeholder="First Name" />
                    </td>
                    <td colspan="3">
                        <!--<input type="text" required v-model="lastname" placeholder="Last Name" />-->
                        <input type="text" v-model="lastname" placeholder="Last Name" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <!--<input type="text" required v-model="address" placeholder="Address" />-->
                        <input type="text" v-model="address" placeholder="Address" />
                    </td>
                    <td colspan="3">
                        <!--<input type="text" required v-model="city" placeholder="City" />-->
                        <input type="text" v-model="city" placeholder="City" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <!--<input type="text" required v-model="state" placeholder="State" />-->
                        <input type="text" v-model="state" placeholder="State" />
                    </td>
                    <td colspan="3">
                        <!--<input type="text" required v-model="zip" placeholder="Zip" />-->
                        <input type="text" v-model="zip" placeholder="Zip" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <!--<input type="text" required v-model="country" placeholder="Country" />-->
                        <input type="text" v-model="country" placeholder="Country" />
                    </td>
                </tr>
            </table>
            <input type="submit" name="Submit Payment" value="Submit Payment" />
        </form>
    </div>
</template>

<script>
    import axios from 'axios'
    import { Store } from '../state/Store'

    export default {
        data() {
            return {
                cardnumber: '', 
                month: '',
                year: '',
                cvv: '',
                firstname: '',
                lastname: '',
                address: '',
                city: '',
                state: '',
                zip: '',
                country: '',
                errors: [],
                //form: {
                //    name: '',
                //    creditcard: '',
                //},
                //order: {
                //    errors: [],
                //    submitSuccess: false,

                //},
                //show: true
            }
        },
        methods: {
            submitForm() {
                axios.post('http://localhost:60568/api/order',
                    {
                        'items': Store.$data.cartItems,
                        'paymentinfo': {
                            'creditcard': {
                                'cardnumber': this.cardnumber,
                                'month': this.month,
                                'year': this.year,
                                'cvv': this.cvv
                            },
                            'address': {
                                'name': `${this.firstname} ${this.lastname}`,
                                'address1': this.address,
                                'city': this.city,
                                'state': this.state,
                                'zipcode': this.zip,
                                'country': this.country
                            }
                        }
                       
                        
                    }, {
                    headers: {
                        //'Content-Type': 'application/x-www-form-urlencoded',
                        'Content-Type': 'application/json',
                    }
                }
            ).then(r => console.log('r: ', JSON.stringify(r, null, 2)));
            },
            //submitForm() {
            //    evt.preventDefault()
            //    axios.post(`http://localhost:60568/api/order`,
            //        {
            //            body: { id: 1 },
            //            headers: {
            //                'Content-type': 'application/x-www-form-urlencoded',
            //            },
            //        }).then(response => {
            //            this.order = response.data
            //        })
            //        .catch(e => {
            //            this.errors.push(e)
            //        })
            //},
            //onReset(evt) {
            //    evt.preventDefault()
            //    /* Reset our form values */
            //    this.form.name = ''
            //    this.form.creditcard = ''
            //    /* Trick to reset/clear native browser form validation state */
            //    this.show = false
            //    this.$nextTick(() => {
            //        this.show = true
            //    })
            //}
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

    .payment-form {
        width: 600px;
        margin-left: auto;
        margin-right: auto;
    }

    input#cvv {
        width: 100%;
    }

    input#month {
        width: 100%;
    }

    input#year {
        width: 100%;
    }


    input[type=text], select {
        width: 100%;
        padding: 12px 20px;
        margin: 8px 0;
        display: inline-block;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
    }

    input[type=submit] {
        width: 100%;
        /*background-color: #4CAF50;*/
        background-color: #5DBCD2;
        padding: 14px 20px;
        margin: 8px 0;
        border: none;
        border-radius: 4px;
        cursor: pointer;
    }

        input[type=submit]:hover {
            background-color: #4798aa;
        }

    div {
        border-radius: 5px;
        background-color: #f2f2f2;
        padding: 20px;
    }

</style>
