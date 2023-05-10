using financeAPI.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.InteropServices;

namespace financeAPI.Data
{
    public static class SeedData
    {
        static public void SeedAll(DataContext db)
        {
            #region TransactionType
            if (db.TransactionType.Count() == 0)
            {
                var transactionTypes = SeedData.PopTransactionType();
                Console.WriteLine($"Criando Tipos de Transações:");
                foreach (var c in transactionTypes)
                {
                    Console.WriteLine($"   {c}");
                }

                db.TransactionType.AddRange(transactionTypes);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Listando Tipos de Transações cadastrados:");
                foreach (var c in db.TransactionType)
                {
                    Console.WriteLine($"   {c}");
                }
            }
            #endregion TransactionType

            #region CostCenter
            if (db.CostCenter.Count() == 0)
            {
                var costCenters = SeedData.PopCostCenter();
                Console.WriteLine($"Criando Centros de Custo:");
                foreach (var c in costCenters)
                {
                    Console.WriteLine($"   {c}");
                }

                db.CostCenter.AddRange(costCenters);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Listando Centros de Custo cadastrados:");
                foreach (var c in db.CostCenter)
                {
                    Console.WriteLine($"   {c}");
                }
            }
            #endregion CostCenter

            #region BankAccount
            if (db.BankAccount.Count() == 0)
            {
                var bankAccounts = SeedData.PopBankAccount();
                Console.WriteLine($"Criando Contas Bancárias:");
                foreach (var c in bankAccounts)
                {
                    Console.WriteLine($"   {c}");
                }

                db.BankAccount.AddRange(bankAccounts);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Listando Contas Bancárias cadastradas:");
                foreach (var c in db.BankAccount)
                {
                    Console.WriteLine($"   {c}");
                }
            }
            #endregion BankAccount

            #region ChartOfAccounts
            if (db.ChartOfAccounts.Count() == 0)
            {
                var chartOfAccounts = SeedData.PopChartOfAccount();
                Console.WriteLine($"Criando Planos de Contas:");
                foreach (var c in chartOfAccounts)
                {
                    Console.WriteLine($"   {c}");
                }

                db.ChartOfAccounts.AddRange(chartOfAccounts);
                db.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Listando Planos de Contas cadastrados:");
                foreach (var c in db.ChartOfAccounts)
                {
                    Console.WriteLine($"   {c}");
                }
            }
            #endregion ChartOfAccounts
        }

        static public IEnumerable<TransactionType> PopTransactionType()
        {
            var transactionTypes = new List<TransactionType>
            {
                new TransactionType
                {
                    Name="Payable"
                },
                new TransactionType
                {
                    Name="Receivable"
                }
            };
            return transactionTypes;
        }
        
        static public IEnumerable<CostCenter> PopCostCenter()
        {
            var costCenters = new List<CostCenter>
            {
                new CostCenter
                {
                    Name="Moema"
                },
                new CostCenter
                {
                    Name="Tucuruvi"
                },
                new CostCenter
                {
                    Name="Pacaembu"
                },
                new CostCenter
                {
                    Name="Santo André"
                },
                new CostCenter
                {
                    Name="Vila Clementino"
                }
            };
            return costCenters;
        }

        static public IEnumerable<BankAccount> PopBankAccount()
        {
            var bankAccounts = new List<BankAccount>
            {
                new BankAccount
                {
                    Name="Itau Moema",
                    Agency=2923,
                    AccountNumber=304022,
                    BankNumber=341,
                    BankName="Itau",
                    Observation=""
                },
                new BankAccount
                {
                    Name="Itau Pacaembu",
                    Agency=2923,
                    AccountNumber=304147,
                    BankNumber=341,
                    BankName="Itau",
                    Observation=""
                },
                new BankAccount
                {
                    Name="Itau Santo Andre",
                    Agency=2923,
                    AccountNumber=304915,
                    BankNumber=341,
                    BankName="Itau",
                    Observation=""
                },
                new BankAccount
                {
                    Name="Itau Vila Clementino",
                    Agency=0440,
                    AccountNumber=228450,
                    BankNumber=341, 
                    BankName="Itau",
                    Observation=""
                },
                new BankAccount
                {
                    Name="Itau Paulista",
                    Agency=7838,
                    AccountNumber=056971,
                    BankNumber=341, 
                    BankName="Itau",
                    Observation=""
                },
                new BankAccount
                {
                    Name="Caixa Santo Andre",
                    Agency=0252,
                    AccountNumber=381670,
                    BankNumber=104,
                    BankName="Caixa",
                    Observation=""
                },
            };
            return bankAccounts;
        }

        static public IEnumerable<ChartOfAccounts> PopChartOfAccount()
        {
            var chartOfAccounts = new List<ChartOfAccounts>
            {

                new ChartOfAccounts
                {
                    Name="Ajuste de caixa (ganho: valores a maior encontrados)",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Ajuste de caixa (perda ou extravio de valores)",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Aluguel, condomínio, IPTU, seguro",
                    ShowIncomeStatement = true 
                },
                new ChartOfAccounts
                {
                    Name="Amortização de empréstimos",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Aquisição de ativos",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Aquisição de máquinas e equipamentos",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Assessorias e serviços especializados",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Comissão de vendedores",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Compra a prazo",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Contabilidade",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Contribuição sindical",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Cursos e treinamentos",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Despesas bancárias",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Despesas jurídicas",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Devolução de vendas",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Distribuição de lucros",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Empréstimos",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - 13º Salário",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Alimentação",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Assistência médica e odontológica",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Exames médicos",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Férias",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - FGTS",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - INSS",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - IRRF",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Rescisões trabalhistas",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Encargos funcionários - Transporte",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Eventos e confraternizações",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Fornecedor",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Fretes",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Impostos - ICMS",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Impostos - IPTU",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Impostos - ISS",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Impostos - Simples nacional",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Infraestrutura - Água",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Infraestrutura - Energia Elétrica",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Infraestrutura - Sistemas de informação e cloud",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Infraestrutura - Telefonia e internet",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Investimento financeiro",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Juros a receber",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Juros e despesas financeiras a pagar",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Manutenção",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Marketing e publicidade",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Material de escritório, consumo e limpeza",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Outras receitas",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Outras taxas de contribuição legal",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Pró-Labore",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Sacolas e embalagens",
                    ShowIncomeStatement = false
                },
                new ChartOfAccounts
                {
                    Name="Salários",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Salários - Adiantamento",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Segurança",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Seguros",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Serviço de limpeza",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Taxas de meios de pagamento (cartões)",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Vendas",
                    ShowIncomeStatement = true
                },
                new ChartOfAccounts
                {
                    Name="Visual merchandising",
                    ShowIncomeStatement = true
                }
            };
            return chartOfAccounts;
        }

    }
}
