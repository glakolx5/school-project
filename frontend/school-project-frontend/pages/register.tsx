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
    else{
      router.push('/')
    }

  }
  return (
    <div className='px-32 py-32'>
      <div>
        Register
      </div>

      <div className='col-span-3 w-full h-auto'>
        <div className='p4'>
          <form onSubmit={handleSubmit}>
            <div className='grid  gap-4  py-5 w-full'>

              <div className='flex flex-col'>
                <label htmlFor="name">Name of the business: </label>
                <input className='py-4 border-2 rounded-lg  flex' type="text" id="name" name='name' required />
              </div>


              <div className='flex flex-col'>
                <label htmlFor="timeFrom">Time from: </label>
                <input className='py-4 border-2 rounded-lg  flex ' type="text" id="timeFrom" name='timeFrom' required />
              </div>

              <div className='flex flex-col'>
                <label htmlFor="timeTo">Time to: </label>
                <input className='py-4 border-2 rounded-lg  flex ' type="text" id="timeTo" name='timeTo' required />

              </div>

              <div className='flex flex-col'>
                <label htmlFor="timeFrom">CVR Number: </label>
                <input className='py-4 border-2 rounded-lg  flex ' type="text" id="cvrNR" name='cvrNR' required />
              </div>

              <div className='flex flex-col'>
                <label htmlFor="address">Address: </label>
                <input className='py-4 border-2 rounded-lg  flex ' type="text" id="address" name='address' required />
              </div>
              <button className=' bg-slate-300 h-16 border-2 rounded-lg hover:bg-gray-700 hover:text-white'>Send request</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

export default register