
        // Verificação inicial de token
        document.addEventListener('DOMContentLoaded', () => {
            try {
                const token = localStorage.getItem('token');
                if (token) {
                    // Aqui você pode adicionar uma verificação de token válido
                    window.location.href = "home.html";
                }
            } catch (error) {
                console.error('Erro ao acessar localStorage:', error);
            }
        });

        // Toggle Password Visibility
        document.getElementById('togglePassword').addEventListener('click', function() {
            const senhaInput = document.getElementById('senha');
            const eyeIcon = document.getElementById('eye-icon');
            
            if (senhaInput.type === 'senha') {
                senhaInput.type = 'text';
                eyeIcon.innerHTML = `
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.878 9.878L3 3m6.878 6.878L21 21"></path>
                `;
            } else {
                senhaInput.type = 'senha';
                eyeIcon.innerHTML = `
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"></path>
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"></path>
                `;
            }
        });

        // Form Submission - IMPROVED ERROR HANDLING
        document.getElementById('loginForm').addEventListener('submit', async function(e) {
            e.preventDefault();
            
            const form = e.target;
            const submitButton = document.getElementById('submitButton');
            const buttonText = document.getElementById('buttonText');
            const buttonSpinner = document.getElementById('buttonSpinner');
            const errorMessage = document.getElementById('errorMessage');
            
            // Reset states
            errorMessage.classList.add('hidden');
            submitButton.disabled = true;
            buttonText.textContent = 'Entrando...';
            buttonSpinner.classList.remove('hidden');
            
            const formData = {
                email: form.email.value.trim(),
                senha: form.senha.value
            };
            
            // Basic validation
            if (!formData.email || !formData.senha) {
                showError('Por favor, preencha todos os campos.');
                return;
            }
            
            if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
                showError('Por favor, insira um e-mail válido.');
                return;
            }
            
            try {
                console.log('Attempting to connect to API...'); // Debug log
                
                const response = await fetch("https://localhost:7027/User/login", {
                    method: "POST",
                    headers: {
                        'Content-Type': 'application/json',
                        'Accept': 'application/json'
                    },
                    body: JSON.stringify(formData)
                });
                
                console.log('Response status:', response.status); // Debug log
                
                const data = await response.json();
                console.log('Response data:', data); // Debug log
                
                if (!response.ok) {
                    throw new Error(data.message || `https error! status: ${response.status}`);
                }
                
                // Store token and user data
                localStorage.setItem('token', data.token);
                localStorage.setItem('user', JSON.stringify(data.user));
                
                // Redirect to home
                window.location.href = "home.html";
                
            } catch (error) {
                console.error('Login error:', error);
                
                // More specific error messages
                if (error.name === 'TypeError' && error.message.includes('fetch')) {
                    showError('Não foi possível conectar ao servidor. Verifique se a API está rodando.');
                } else if (error.message.includes('NetworkError')) {
                    showError('Erro de rede. Verifique sua conexão com a internet.');
                } else {
                    showError(error.message || 'Erro ao fazer login. Por favor, tente novamente.');
                }
            } finally {
                submitButton.disabled = false;
                buttonText.textContent = 'Entrar';
                buttonSpinner.classList.add('hidden');
            }
            
            function showError(message) {
                errorMessage.textContent = message;
                errorMessage.classList.remove('hidden');
                submitButton.disabled = false;
                buttonText.textContent = 'Entrar';
                buttonSpinner.classList.add('hidden');
            }
        });
