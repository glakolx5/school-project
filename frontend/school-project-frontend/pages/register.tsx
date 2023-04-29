import { useRouter } from 'next/router';

function register() {

  //router that I will use after successfull posting
  const router = useRouter();

  //Button that handle submit in async  
  const handleSubmit = async (event: any) => {

    //Blocking default click handling
    event.preventDefault()

    //Data I will be sending to backend controller from rendered page
    const data = {
      name: event.target.name.value,
      timeFrom: event.target.timeFrom.value,
      timeTo: event.target.timeTo.value,
      cvrNR: event.target.cvrNR.value,
      address: event.target.address.value,
    }

    //Becomes JSON data
    const JSONdata = JSON.stringify(data)

    //backend controller
    const endPoint = "http://localhost:5216/api/Info";

    //This method is POST and json
    const options = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      //Body from rendered page
      body: JSONdata,
    }

    //This will make sure that POST is happening, then a status response from backend controller
    const response = await fetch(endPoint, options)

    // Status code
    const result = response.status;

    if (result === 404) {
      return (
        <div>
          404
        </div>
      )
    }
    else {
      router.push('/registered')
    }

  }
  return (
    <div className='lg:px-32 lg:py-32 py-32 mx-10'>
      <div className='text-xl'>
        Please fill this form
      </div>
      {/* Start of the form */}
      <div className='col-span-3 w-full h-auto'>
        <div className='p4'>
          <form onSubmit={handleSubmit}>
            <div className='grid  gap-4  py-5 w-full'>
              <div className='flex flex-col'>

                <label htmlFor="name">Name of the business: </label>
                <input className='lg:py-4 py-2 border-2 rounded-lg  flex' type="text" id="name" name='name' required />
              
              </div>

              {/* Selection of times */}
              <div className='grid grid-cols-2'>
                <div className='flex flex-col w-2/3'>
                  <label htmlFor="timeFrom">Time from: </label>
                  <select className='py-5' name="Time from" id="timeFrom">
                    <option value="07:00">07:00</option>
                    <option value="08:00">08:00</option>
                    <option value="09:00">09:00</option>
                    <option value="10:00">10:00</option>
                    <option value="11:00">11:00</option>
                  </select>
                </div>
                <div className='flex flex-col w-2/3 '>
                  <label htmlFor="timeTo">Time to: </label>
                  <select className='py-5 ' name="Time from" id="timeTo">
                    <option value="15:00 ">15:00</option>
                    <option value="16:00">16:00</option>
                    <option value="17:00">17:00</option>
                    <option value="18:00">18:00</option>
                    <option value="19:00">19:00</option>
                  </select>
                </div>
              </div>
              {/* Rest of the form to fill */}
              <div className='flex flex-col'>

                <label htmlFor="timeFrom">CVR Number: </label>
                <input className='lg:py-4 py-2 border-2 rounded-lg  flex ' type="text" id="cvrNR" name='cvrNR' required />
              </div>

              <div className='flex flex-col'>
                
                <label htmlFor="address">Address: </label>
                <input className='lg:py-4 py-2 border-2 rounded-lg  flex ' type="text" id="address" name='address' required />
              
              </div>
              {/* Button and activates handleSubmit() function*/}
              <button className=' bg-violet-300 h-16 border-2 rounded-lg hover:bg-gray-700 hover:text-white'>Send request</button>
            
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

export default register