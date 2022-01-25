 <template>
       <div class="container">
         <div class="subform">
           <div class="subforum-title">
              <h1>General Information</h1>
           </div>
         </div>
         <div class="subforum-row">
              <div class="subforum-icon subforum-column center" > 
                  <i class="fas fa-laptop"></i>
              </div>
              <div class="subforum-description subforum-column">
                  <h1>Descriptiption Title <small>Posted by <a href="">User</a> 15 Jan 2022</small></h1>
                  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Lectus sit amet est placerat. Lacus viverra vitae congue eu consequat ac felis donec et. 
                    Tempus quam pellentesque nec nam aliquam sem et tortor. Mi proin sed libero enim. Purus non enim praesent elementum facilisis. Amet nisl purus in mollis nunc sed.</p>
                  <a class="post-link" href=""><router-link to="/Post">Reply</router-link></a>
                  <a class="post-link" href=""><router-link to="/">Save</router-link></a>
              </div>
         </div>
       </div>
</template>

<script>
// import { defineComponent } from '@vue/composition-api'

// export default defineComponent({
//     setup() {
        
//     },
// })
</script>


<style scoped>

   *{
     box-sizing: border-box;
   }

  a{
    color: rgb(153, 149, 163);
    font-weight: bolder;
  }

  .post-link > a{
    color: white;
    padding-right: 10px;
    font-size: 12px;
  }

  h1{
    font-size: 16px;
    font-weight: bolder;
    color: white;
  }

  /*Body*/
  .container{
    margin: 20px;
    padding:20px;
    background: rgb(173, 173, 173);
    border-radius: 5px;
  }

  /* .div-container{
    align-self: center;
  }
   */
  .subforum{
    margin-top: 20px;
  }

  .subforum-title{
    background-color:rgb(131, 54, 54);
    padding: 10px;
    border-radius: 5px;
    margin: 4px;
  }

  .subforum-row{
    display: grid;
    grid-template-columns: 7% 93% ;
  }

  .subforum-column{
    border-radius: 5px;
    margin: 4px;
    background-color: rgb(145, 39, 39);
  }

  .subforum-description{
    padding:10px;
  }

  .center{
    display:flex;
    justify-content: center;
    align-items: center;
  }

  .subforum-icon{
    font-size:30px;
  }
   
</style>
